
namespace ServerSide.Servicing
{
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    using ServerSide.Handling;
    using ServerSide.Logging;
    using ServerSide.Networking;
    using ServerSide.Processing;

    public class Server : IServer
    {
        private readonly Dictionary<string, string> _allCommands = new Dictionary<string, string>()
                                                                       {
                                                                           { "begin", "Запускает работу сервера" },
                                                                           { "end", "Завершает работу сервера" },
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
                                                                               "close",
                                                                               "Выключает основные модули сервера"
                                                                           }
                                                                       };

        private ILog _log;

        private UserBase _userBase;

        private IConnection _connectionHandler;

        private IMessageHandler _messageHandler;

        private ConnectionSender _connectionSender;

        public Server(IPAddress ip, int port, int bufferSize, int countConnections)
        {
            BufferSize = bufferSize;
            MaxCountConnections = countConnections;
            Address = new IPEndPoint(ip, port);
            _log = new Log(512);
            _userBase = new UserBase();
            _messageHandler = new MessageHandler(256, _userBase);
            _connectionHandler = new ConnectionReceiver(new IPEndPoint(ip, port), bufferSize, countConnections);
            _connectionSender = new ConnectionSender(256);
        }

        public event ProcessEventHandler ModuleChangeState = delegate { };

        public event ProcessEventHandler StateChanged = delegate { };

        public ILog Log => _log;

        public bool IsActive { get; private set; }

        public IPEndPoint Address { get; }

        public int BufferSize { get; }

        public int MaxCountConnections { get; }

        public void Subscribing()
        {
            ModuleChangeState += _log.AddRecord;

            StateChanged += ModuleChangeState;

            _messageHandler.StateChanged += ModuleChangeState;
            _messageHandler.OperationHandled += _log.AddRecord;
            _messageHandler.OperationHandled += _connectionSender.AddMessage;

            _connectionHandler.StateChanged += ModuleChangeState;
            _connectionHandler.OperationHandled += _log.AddRecord;
            _connectionHandler.OperationHandled += _messageHandler.AddMessage;

            _userBase.Action += _log.AddRecord;
            _userBase.BirthDay += _log.AddRecord;
            _userBase.OperationCompleted += _log.AddRecord;

            _connectionSender.StateChanged += ModuleChangeState;
            _connectionSender.OperationHandled += _log.AddRecord;

            _log.StateChanged += ModuleChangeState;
        }

        public void Start()
        {
            IsActive = true;
            StateChanged(this, new ProcessEventArgs("Сервер запущен"));
        }

        public void End()
        {
            IsActive = false;
            StateChanged(this, new ProcessEventArgs("Выключение сервера..."));
            EndModules();
        }

        public string Manage(string command)
        {
            if (IsActive || command == "begin")
            {
                switch (command)
                {
                    case "info":
                        {
                            StateChanged(this, new ProcessEventArgs("Сервер работает"));
                            return "Сервер включен";
                        }

                    case "help":
                        {
                            return Help();
                        }

                    case "begin":
                        {
                            Start();
                            return "Сервер включен";
                        }

                    case "end":
                        {
                            End();
                            return "Сервер выключен";
                        }

                    case "start":
                        {
                            StartModules();
                            return "Модули сервера запущены";
                        }

                    case "close":
                        {
                            EndModules();
                            return "Работа модулей сервера завершена";
                        }

                    default:
                        {
                            return "Такой команды не существует. Для получения списка доступных команд введите 'help'";
                        }
                }
            }
            else
            {
                return "Сервер выключен. Для запуска введите 'begin'";
            }
        }

        private string Help()
        {
            var info = new StringBuilder(1024);
            info.AppendLine("\nСписок команд:\n");
            int commandNumber = 0;
            foreach (KeyValuePair<string, string> command in _allCommands)
            {
                info.AppendLine();
                info.AppendLine($"{++commandNumber}) {command.Key} - {command.Value}");
            }

            return info.ToString();
        }

        private void StartModules()
        {
            _log.Start();
            _connectionSender.Start();
            _messageHandler.Start();
            _connectionHandler.Start();
        }

        private void EndModules()
        {
            _connectionHandler.End();
            _messageHandler.End();
            _connectionSender.End();
            _log.End();
        }
    }
}