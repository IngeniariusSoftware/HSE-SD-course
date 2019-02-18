
namespace ServerSide.Networking
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;

    using ServerSide.Processing;

    public class ConnectionSender : IConnection
    {
        private readonly EventWaitHandle _packageAdded = new AutoResetEvent(false);

        private readonly EventWaitHandle _packageRemoved = new AutoResetEvent(false);

        private readonly EventWaitHandle _isEnd = new AutoResetEvent(false);

        private readonly object _locker = new object();

        private readonly Queue<(object parcel, IPEndPoint address)> _packages;

        private int _sizePackageQueue;

        private BinaryFormatter _binaryFormatter = new BinaryFormatter();

        public ConnectionSender(int sizePackageQueue)
        {
            SizePackageQueue = sizePackageQueue;
            _packages = new Queue<(object datagram, IPEndPoint address)>(sizePackageQueue);
        }

        public event ProcessEventHandler StateChanged = delegate { };

        public event ConnectionEventHandler OperationHandled = delegate { };

        public int SizePackageQueue
        {
            get => _sizePackageQueue;

            set => _sizePackageQueue = Math.Max(1, value);
        }

        public bool IsActive { get; private set; }

        public void Start()
        {
            if (!IsActive)
            {
                IsActive = true;
                StateChanged(this, new ProcessEventArgs("Модуль отправки сообщений запущен"));
                new Thread(Sending) { Name = "Поток отправки сообщений" }.Start();
                StateChanged(this, new ProcessEventArgs("Запущена отправка сообщений"));
            }
            else
            {
                StateChanged(this, new ProcessEventArgs("Модуль обработки отправки уже включен!"));
            }
        }

        public void End()
        {
            if (IsActive)
            {
                IsActive = false;
                while (_isEnd.WaitOne(100))
                {
                    StateChanged(this, new ProcessEventArgs("Ожидание завершения работы модуля отправки сообщений..."));
                }

                StateChanged(this, new ProcessEventArgs("Модуль отправки сообщений выключен"));
            }
            else
            {
                StateChanged(this, new ProcessEventArgs("Модуль отправки сообщений уже выключен!"));
            }
        }

        public void AddMessage(object sender, ConnectionEventArgs e)
        {
            if (IsActive)
            {
                lock (_locker)
                {
                    if (_packages.Count > SizePackageQueue)
                    {
                        StateChanged(this, new ProcessEventArgs("Очередь отправки сообщений переполнена!\n"));
                        _packageRemoved.WaitOne(100);
                    }

                    lock (_packages)
                    {
                        _packages.Enqueue((e.Data, e.Address));
                    }

                    _packageAdded.Set();
                }
            }
            else
            {
                StateChanged(this, new ProcessEventArgs("Модуль отправки сообщений отключен!\n"));
            }
        }

        private void Sending()
        {
            IsActive = true;
            while (IsActive || _packages.Count > 0)
            {
                _packageAdded.WaitOne(100);
                while (_packages.Count > 0)
                {
                    (object parcel, IPEndPoint address) package;
                    lock (_packages)
                    {
                        package = _packages.Dequeue();
                    }

                    _packageRemoved.Set();
                    SendMessage(package.parcel, package.address);
                }
            }

            _isEnd.Set();
        }

        private void SendMessage(object data, IPEndPoint address)
        {
            using (var memory = new MemoryStream())
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _binaryFormatter.Serialize(memory, data);

                try
                {
                    socket.Connect(address.Address, address.Port);
                    socket.Send(memory.ToArray());
                    OperationHandled(this, new ConnectionEventArgs("Сообщение отправлено", null, address));
                }
                catch (Exception ex)
                {
                    OperationHandled(
                        this,
                        new ConnectionEventArgs("Сообщение не было отправлено!\n\n" + ex, null, address));
                }

                socket.Close();
            }
        }
    }
}