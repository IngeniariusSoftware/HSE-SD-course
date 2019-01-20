
namespace ServerSide.Servicing
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;

    using ServerSide.Connecting;
    using ServerSide.Interfaces;
    using ServerSide.Logging;
    using ServerSide.Timing;

    public class Server : IServer, IProcess
    {
        private readonly Dictionary<string, string> _allCommands = new Dictionary<string, string>()
                                                                       {
                                                                           {
                                                                               "block xxx.xxx.xxx.xxx",
                                                                               "Блокирует подключения от ip клиента"
                                                                           },
                                                                           { "close", "Завершает работу сервера" },
                                                                           {
                                                                               "end",
                                                                               "Завершает работу основных модулей"
                                                                           },
                                                                           {
                                                                               "help",
                                                                               "Показывает список доступных команд"
                                                                           },
                                                                           { "info", "Выводит информацию о сервере" },
                                                                           {
                                                                               "start",
                                                                               "Запускает основные модули сервера"
                                                                           },
                                                                           {
                                                                               "unlock xxx.xxx.xxx.xxx",
                                                                               "Снимает блокировку подключений от ip клиента"
                                                                           }
                                                                       };

        private bool _isActive; 

        private IConnectionHandler _connectionHandler;

        private ITimeObserver _timer;

        private IPEndPoint _address;

        private int _bufferSize;

        private int _maxCountConnections;

        private ILog _log;

        public Server(IPAddress ip, int port, int bufferSize, int countConnections, ILog log)
        {
            _address = new IPEndPoint(ip, port);
            _bufferSize = bufferSize;
            _maxCountConnections = countConnections;
            _log = log;
            _timer = new TimeObserver();
            OperationHandled += _log.MakeRecord;
            _timer.ChangeState += _log.MakeRecord;
        }

        public event ServerEventHandler OperationHandled = delegate { };

        public bool IsActive => _isActive;

        public IPEndPoint Address => _address;

        public void Start()
        {
            _isActive = true;
            OperationHandled(this, new ServerEventArgs("Сервер запущен"));
            Manage();
        }

        public void End()
        {
            _isActive = false;
            OperationHandled(this, new ServerEventArgs("Выключение сервера"));
        }

        private void Manage()
        {
            OperationHandled(this, new ServerEventArgs("Командный терминал управления сервером запущен"));
            string command;
            do
            {
                Console.WriteLine("Введите команду для управления сервером\n");
                command = Console.ReadLine();
                Console.WriteLine();

                switch (command)
                {
                    case "info":
                        {
                            OperationHandled(this, new ServerEventArgs("Сервер работает"));
                            break;
                        }

                    case "help":
                        {
                            Help();
                            break;
                        }

                    case "close":
                        {
                            if (_timer.IsActive)
                            {
                                _timer.End();
                            }

                            if (_connectionHandler != null && _connectionHandler.IsActive)
                            {
                                _connectionHandler.End();
                            }

                            End();
                            break;
                        }

                    case "start":
                        {
                            if (_timer.IsActive)
                            {
                                Console.WriteLine("\nТаймер уже включен\n");
                            }
                            else
                            {
                                _timer.Start();
                            }

                            if (_connectionHandler != null && _connectionHandler.IsActive)
                            {
                                Console.WriteLine("\nМодуль обработки подключений уже включен\n");
                            }
                            else
                            {
                                _connectionHandler = new ConnectionHandler(
                                    new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp),
                                    Address,
                                    _bufferSize,
                                    _maxCountConnections);
                                _connectionHandler.OperationHandled += _log.MakeRecord;
                                _connectionHandler.Start();
                            }

                            break;
                        }

                    case "end":
                        {
                            if (!_timer.IsActive)
                            {
                                Console.WriteLine("\nТаймер уже выключен\n");
                            }
                            else
                            {
                                _timer.End();
                            }

                            if (_connectionHandler == null || !_connectionHandler.IsActive)
                            {
                                Console.WriteLine("\nМодуль обработки подключений уже выключен\n");
                            }
                            else
                            {
                                _connectionHandler.End();
                            }

                            break;
                        }

                    default:
                        {
                            Console.WriteLine(
                                "\nТакой команды не существует\nДля получения списка доступных команд введите \"help\"\n");
                            break;
                        }
                }
            }
            while (command != "close");
        }

        private void Help()
        {
            Console.WriteLine("\nСписок команд:\n");
            int commandNumber = 0;
            foreach (KeyValuePair<string, string> command in _allCommands)
            {
                Console.WriteLine($"{++commandNumber}) {command.Key} - {command.Value}\n");
            }
        }
    }
}