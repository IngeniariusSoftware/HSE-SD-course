
namespace ClientSide
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text.RegularExpressions;

    using Datagrams;

    using UserManagement.Users;

    public class Client
    {
        private readonly BinaryFormatter _formatter = new BinaryFormatter();

        private Regex _socketValueChecker = new Regex(
            @"^((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)(\:\d{1,5})$");

        private string _serverAddress = "192.168.1.38:904";

        private byte[] buffer = new byte[16384];

        private int _timeForWaiting = 1000;

        private IPEndPoint _clientAddress;

        public static Client Instance { get; } = new Client();

        public Guid Token { get; set; }

        public IUser User { get; set; }

        public IUser LocalUser { get; set; }

        public string ServerAddress
        {
            get => _serverAddress;

            set
            {
                if (_socketValueChecker.IsMatch(value))
                {
                    _serverAddress = value;
                }
            }
        }

        public Datagram GetAnswer(Datagram question)
        {
            if (SendMessage(question))
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(_clientAddress);
                socket.Listen(10);
                var answer = socket.AcceptAsync();
                answer.Wait(_timeForWaiting);
                if (answer.IsCompleted && answer.Result != null)
                {
                    int length = 0;
                    var memory = new MemoryStream();
                    Socket client = answer.Result;

                    do
                    {
                        int size = client.Receive(buffer);
                        memory.Write(buffer, 0, size);
                        length += size;
                    }
                    while (client.Available > 0);

                    memory.Position = 0;
                    client.Close();
                    socket.Close();

                    if (length > 0)
                    {
                        try
                        {
                            return (Datagram)_formatter.Deserialize(memory);
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    socket.Close();
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        public bool CheckConnection()
        {
            bool result;
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(ServerAddress.Split(':')[0], int.Parse(ServerAddress.Split(':')[1]));
                _clientAddress = (IPEndPoint)socket.LocalEndPoint;
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            socket.Close();
            return result;
        }

        private bool SendMessage(Datagram question)
        {
            bool result;
            using (var memory = new MemoryStream())
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _formatter.Serialize(memory, question);
                try
                {
                    socket.Connect(ServerAddress.Split(':')[0], int.Parse(ServerAddress.Split(':')[1]));
                    socket.Send(memory.GetBuffer());
                    _clientAddress = (IPEndPoint)socket.LocalEndPoint;
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }

                socket.Close();
            }

            return result;
        }
    }
}