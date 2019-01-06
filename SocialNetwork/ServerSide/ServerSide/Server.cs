namespace ServerSide
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Server
    {
        new Dictionary<string, string> allCommands =
            new Dictionary<string, string>
                {
                    { "help", "Показывает список доступных команд" },
                    { "close", "Завершает работу сервера" },
                    { "info", "Выводит информацию о сервере" }
                };

        private Socket socket;

        public string GetSocket => socket.ToString();


        private byte[] buffer;

        private volatile bool isWorked;

        public bool IsWorked => isWorked;
        
        public Log log;

        public int maxCountConnections { get; }


        public Server(IPAddress ip, int port, int bufferSize, int countConnections)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(ip, port));
            buffer = new byte[bufferSize];
            isWorked = false;
            maxCountConnections = countConnections;
            log = new Log();
            log.StartLogging();
            log.MakeLogServerInfo(socket, isWorked, buffer.Length, maxCountConnections);
        }

        public async void Start()
        {
            isWorked = true;
            log.MakeLogServerInfo(socket, isWorked, buffer.Length, maxCountConnections);
            socket.Listen(maxCountConnections);
            await Task.Run(() => HandlingConnections());
        }

        private void HandlingConnections()
        {
            Stopwatch timer = new Stopwatch();
            while (isWorked)
            {
                Socket client;
                try
                {
                    client = socket.Accept();
                    int messageSize = client.Receive(buffer);
                    timer.Start();
                    Console.WriteLine(Encoding.Unicode.GetString(buffer, 0, messageSize));
                    log.MakeLogOperationInfo(client, messageSize / 1000.0, timer.ElapsedMilliseconds / 1000.0);
                    timer.Reset();
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
                catch (Exception ex)
                {
                    if (isWorked)
                    {
                        log.MakeLog("Клиент разорвал существующее соединение\n\n" + ex + "\n");
                    }
                    else
                    {
                        log.MakeLog("Сервер завершает работу\nСоединения будут разорваны\n\n" + ex + "\n");
                    }
                }
            }

            log.EndLogging();
        }

        public void Manage()
        {
            Console.WriteLine("Командный терминал управления сервером запущен\n");
            string command = string.Empty;
            while (command != "close")
            {
                Console.WriteLine("Введите команду для управления сервером\n");
                command = Console.ReadLine();
                switch (command)
                {
                    case "info":
                        {
                            log.MakeLogServerInfo(socket, isWorked, buffer.Length, maxCountConnections);
                            break;
                        }

                    case "help":
                        {
                            Help();
                            break;
                        }

                    case "close":
                        {
                            End();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nТакой команды не существует\nДля получения списка доступных команд введите \"help\"\n");
                            break;
                        }
                }
            }
        }

        private void Help()
        {
            Console.WriteLine("\nСписок команд:\n");
            foreach (KeyValuePair<string, string> command in allCommands)
            {
                Console.WriteLine($"{command.Key} - {command.Value}\n");
            }
        }

        public void End()
        {
            isWorked = false;
            socket.Close();
        }
    }
}