
namespace ServerSide.Networking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    using ServerSide.Processing;

    public class ConnectionReceiver : IConnection
    {
        private readonly EventWaitHandle _isEnd = new AutoResetEvent(false);

        private Socket _socket;

        private byte[] _buffer;

        private IPEndPoint _address;

        private Dictionary<IPAddress, (double Overload, DateTime LastConnectionTime)> _clients =
            new Dictionary<IPAddress, (double Overload, DateTime LastConnectionTime)>();

        public ConnectionReceiver(IPEndPoint address, int bufferSize, int countConnections)
        {
            _address = address;
            _buffer = new byte[bufferSize];
            MaxCountConnections = countConnections;
        }

        public event ProcessEventHandler StateChanged = delegate { };

        public event ConnectionEventHandler OperationHandled = delegate { };

        public bool IsActive { get; private set; }

        public int MaxCountConnections { get; }

        public double BufferSize => _buffer.Length;

        public void Start()
        {
            if (!IsActive)
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Bind(_address);
                IsActive = true;
                StateChanged(this, new ProcessEventArgs("Модуль обработки подключений запущен"));
                _socket.Listen(MaxCountConnections);

                new Thread(Handle) { Name = "Поток обработки подключений" }.Start();
                StateChanged(this, new ProcessEventArgs("Обработка подключений запущена"));
            }
            else
            {
                StateChanged(this, new ProcessEventArgs("Модуль обработки подключений уже включен!"));
            }
        }

        public void End()
        {
            if (IsActive)
            {
                IsActive = false;
                _socket.Close();

                while (_isEnd.WaitOne(100))
                {
                    StateChanged(
                        this,
                        new ProcessEventArgs("Ожидание завершения работы модуля обработки подключений..."));
                }

                StateChanged(this, new ProcessEventArgs("Модуль обработки подключений выключен"));
            }
            else
            {
                StateChanged(this, new ProcessEventArgs("Модуль обработки подключений уже выключен!"));
            }
        }

        private void Handle()
        {
            while (IsActive)
            {
                try
                {
                    Socket client = _socket.Accept();
                    if (CheckClient(client))
                    {
                        int messageSize = client.Receive(_buffer);
                        OperationHandled(
                            this,
                            new ConnectionEventArgs(
                                "Подключение обработано",
                                _buffer.Take(messageSize).ToArray(),
                                (IPEndPoint)client.RemoteEndPoint));
                    }
                    else
                    {
                        OperationHandled(
                            this,
                            new ConnectionEventArgs(
                                "Подключение сброшено. Превышен лимит запросов!",
                                new byte[0],
                                (IPEndPoint)client.RemoteEndPoint));
                    }

                    client.Close();
                }
                catch (Exception ex)
                {
                    if (IsActive)
                    {
                        StateChanged(this, new ProcessEventArgs($"Клиент разорвал существующее соединение\n\n{ex}\n"));
                    }
                    else
                    {
                        StateChanged(
                            this,
                            new ProcessEventArgs(
                                $"Модуль обработки подключений завершает работу\nСоединения будут разорваны\n\ne{ex}\n"));
                    }
                }
            }

            _isEnd.Set();
        }

        private bool CheckClient(Socket connection)
        {
            IPAddress address = ((IPEndPoint)connection.RemoteEndPoint).Address;
            if (_clients.ContainsKey(address))
            {
                var client = _clients[address];
                client.Overload = Math.Max(
                    0,
                    client.Overload + 1 - (DateTime.Now - client.LastConnectionTime).TotalSeconds * 4);
                client.LastConnectionTime = DateTime.Now;
                _clients[address] = client;

                if (client.Overload < 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                _clients[address] = (0, DateTime.Now);
                return true;
            }
        }
    }
}