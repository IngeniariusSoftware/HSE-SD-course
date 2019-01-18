
namespace ServerSide.Connecting
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;

    using ServerSide.Servicing;

    public class ConnectionHandler : IConnectionHandler
    {
        private bool _isWorking;

        private Socket _socket;

        private byte[] _buffer;

        private bool _isActive;

        public ConnectionHandler(Socket socket, IPEndPoint address, int bufferSize, int countConnections)
        {
            _socket = socket;
            _socket.Bind(address);
            _buffer = new byte[bufferSize];
            MaxCountConnections = countConnections;
        }

        public event ServerEventHandler OperationHandled = delegate { };

        public bool IsActive => _isActive;

        public int MaxCountConnections { get; }

        public double BufferSize => _buffer.Length;

        public IPEndPoint Address => (IPEndPoint)_socket.LocalEndPoint;

        public void Start()
        {
            _isActive = true;
            OperationHandled(this, new ServerEventArgs("Модуль обработки подключений запущен"));
            _socket.Listen(MaxCountConnections);
            var connectionHandlerThread =
                new Thread(Handle) { Name = "Поток обработки подключений", Priority = ThreadPriority.Highest };
            OperationHandled(this, new ServerEventArgs("Запущена обработка подключений"));
            connectionHandlerThread.Start();
        }

        public void End()
        {
            _isActive = false;
            _socket.Close();
            while (_isWorking)
            {
                OperationHandled(this, new ServerEventArgs("Ожидание завершения работы модуля обработки подключений..."));
                Thread.Sleep(500);
            }

            OperationHandled(this, new ServerEventArgs("Модуль обработки подключений выключен"));
        }

        private void Handle()
        {
            var timer = new Stopwatch();
            _isWorking = true;
            while (_isActive)
            {
                Socket client;
                try
                {
                    client = _socket.Accept();
                    int messageSize = client.Receive(_buffer);
                    timer.Start();
                    Console.WriteLine(Encoding.UTF8.GetString(_buffer, 0, messageSize));
                    OperationHandled(
                        this,
                        new ServerEventArgs(
                            (IPEndPoint)client.LocalEndPoint,
                            messageSize,
                            timer.ElapsedMilliseconds,
                            "Сервер обработал сообщение"));
                    timer.Reset();
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
                catch (Exception ex)
                {
                    if (_isActive)
                    {
                        OperationHandled(
                            this,
                            new ServerEventArgs("Клиент разорвал существующее соединение\n\n" + ex));
                    }
                    else
                    {
                        OperationHandled(
                            this,
                            new ServerEventArgs(
                                "Модуль обработки подключений завершает работу\nСоединения будут разорваны\n\n" + ex));
                    }
                }
            }

            _isWorking = false;
        }
    }
}