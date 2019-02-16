
namespace ServerSide.Handling
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;

    using Datagrams;

    using ServerSide.Networking;
    using ServerSide.Processing;

    using UserManagement.Users;

    public class MessageHandler : IMessageHandler
    {
        private readonly EventWaitHandle _packageAdded = new AutoResetEvent(false);

        private readonly EventWaitHandle _packageRemoved = new AutoResetEvent(false);

        private readonly EventWaitHandle _isEnd = new AutoResetEvent(false);

        private readonly object _locker = new object();

        private readonly Queue<(object datagram, IPEndPoint address)> _packages;

        private Stopwatch _timer = new Stopwatch();

        private int _sizePackageQueue;

        private BinaryFormatter _binaryFormatter = new BinaryFormatter();

        private UserBase _userBase;

        public MessageHandler(int sizePackageQueue, UserBase userBase)
        {
            SizePackageQueue = sizePackageQueue;
            _packages = new Queue<(object datagram, IPEndPoint address)>(sizePackageQueue);
            _userBase = userBase;
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
                StateChanged(this, new ProcessEventArgs("Модуль обработки сообщений запущен"));
                new Thread(Handling) { Name = "Поток обработки сообщений" }.Start();
                StateChanged(this, new ProcessEventArgs("Запущена обработка сообщений"));
            }
            else
            {
                StateChanged(this, new ProcessEventArgs("Модуль обработки сообщений уже включен!"));
            }
        }

        public void End()
        {
            if (IsActive)
            {
                IsActive = false;
                while (_isEnd.WaitOne(100))
                {
                    StateChanged(
                        this,
                        new ProcessEventArgs("Ожидание завершения работы модуля обработки сообщений..."));
                }

                StateChanged(this, new ProcessEventArgs("Модуль обработки сообщений выключен"));
            }
            else
            {
                StateChanged(this, new ProcessEventArgs("Модуль обработки сообщений уже выключен!"));
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
                        StateChanged(this, new ProcessEventArgs("Очередь обработки сообщений переполнена!\n"));
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
                StateChanged(this, new ProcessEventArgs("Модуль обработки сообщений отключен!\n"));
            }
        }

        private void Handling()
        {
            IsActive = true;
            while (IsActive || _packages.Count > 0)
            {
                _packageAdded.WaitOne(100);
                while (_packages.Count > 0)
                {
                    (object, IPEndPoint) message;
                    lock (_packages)
                    {
                        message = _packages.Dequeue();
                    }

                    _packageRemoved.Set();
                    HandleMessage(message);
                }
            }

            _isEnd.Set();
        }

        private void HandleMessage((object datagram, IPEndPoint address) package)
        {
            _timer.Start();
            Datagram datagram = null;

            try
            {
                var data = (byte[])package.datagram;
                if (data.Length > 0)
                {
                    datagram = (Datagram)_binaryFormatter.Deserialize(new MemoryStream((byte[])package.datagram));
                }
            }
            catch (Exception ex)
            {
                OperationHandled(
                    this,
                    new ConnectionEventArgs(
                        "Ошибка десериализации \n\n" + ex,
                        new Datagram("server", Guid.Empty, "serializeError", null, null),
                        package.address,
                        _timer.ElapsedMilliseconds));
            }

            if (datagram != null)
            {
                if (datagram.Action != "register" && datagram.Action != "authentication" && datagram.Action != "check")
                {
                    if (_userBase.CheckSession(datagram.UserLogin, datagram.Token))
                    {
                        switch (datagram.Action)
                        {
                            case "get":
                                {
                                    object information = _userBase.GetInformation(
                                        (string)datagram.Data,
                                        datagram.Target);
                                    if (information != null)
                                    {
                                        OperationHandled(
                                            this,
                                            new ConnectionEventArgs(
                                                $"Найдена информация по запросу пользователя {datagram.UserLogin}",
                                                new Datagram(
                                                    "server",
                                                    datagram.Token,
                                                    "success",
                                                    "information",
                                                    information),
                                                package.address,
                                                _timer.ElapsedMilliseconds));
                                    }
                                    else
                                    {
                                        OperationHandled(
                                            this,
                                            new ConnectionEventArgs(
                                                $"По запросу пользователя {datagram.UserLogin} ничего не найдено!",
                                                new Datagram("server", datagram.Token, "error", "information", null),
                                                package.address,
                                                _timer.ElapsedMilliseconds));
                                    }

                                    break;
                                }

                            case "update" when datagram.Data is IUser user:
                                {
                                    if (_userBase.UpdateUserInfo(user))
                                    {
                                        OperationHandled(
                                            this,
                                            new ConnectionEventArgs(
                                                $"Информация о пользователе {datagram.UserLogin} успешно обновлена",
                                                new Datagram("server", datagram.Token, "success", "update", null),
                                                package.address,
                                                _timer.ElapsedMilliseconds));
                                    }
                                    else
                                    {
                                        OperationHandled(
                                            this,
                                            new ConnectionEventArgs(
                                                $"Во время обновления информации о пользователе {datagram.UserLogin} возникли ошибки!",
                                                new Datagram("server", datagram.Token, "unregistered", "user", null),
                                                package.address,
                                                _timer.ElapsedMilliseconds));
                                    }

                                    break;
                                }

                            case "add" when datagram.Target == "friend":
                            case "remove" when datagram.Target == "friend":
                                {
                                    if (_userBase.ChangeUserFriend(
                                        datagram.UserLogin,
                                        datagram.Action,
                                        (string)datagram.Data))
                                    {
                                        OperationHandled(
                                            this,
                                            new ConnectionEventArgs(
                                                $"Пользователь {datagram.UserLogin} успешно изменил список друзей",
                                                new Datagram("server", datagram.Token, "success", "update", null),
                                                package.address,
                                                _timer.ElapsedMilliseconds));
                                    }
                                    else
                                    {
                                        OperationHandled(
                                            this,
                                            new ConnectionEventArgs(
                                                $"Во время изменения списка друзей пользователя {datagram.UserLogin} возникли ошибки",
                                                new Datagram("server", datagram.Token, "success", "update", null),
                                                package.address,
                                                _timer.ElapsedMilliseconds));
                                    }

                                    break;
                                }

                            case "add" when datagram.Target != "friend":
                            case "remove" when datagram.Target != "friend":
                                {
                                    if (_userBase.CreateNews(datagram.UserLogin, datagram.Target, datagram.Data, null))
                                    {
                                        OperationHandled(
                                            this,
                                            new ConnectionEventArgs(
                                                $"Пользователь {datagram.UserLogin} успешно добавил новость",
                                                new Datagram("server", datagram.Token, "success", "update", null),
                                                package.address,
                                                _timer.ElapsedMilliseconds));
                                    }
                                    else
                                    {
                                        OperationHandled(
                                            this,
                                            new ConnectionEventArgs(
                                                $"Во время добавления новости пользователем {datagram.UserLogin} возникли ошибки",
                                                new Datagram("server", datagram.Token, "success", "update", null),
                                                package.address,
                                                _timer.ElapsedMilliseconds));
                                    }

                                    break;
                                }
                        }
                    }
                    else
                    {
                        OperationHandled(
                            this,
                            new ConnectionEventArgs(
                                $"Во время проверки пользователя {datagram.UserLogin} возникли ошибки!",
                                new Datagram("server", datagram.Token, "error", "authorization", null),
                                package.address,
                                _timer.ElapsedMilliseconds));
                    }
                }
                else
                {
                    switch (datagram.Action)
                    {
                        case "register" when datagram.Data is IUser user:
                            {
                                Guid sessionID = _userBase.AddUser(user);
                                if (sessionID != Guid.Empty)
                                {
                                    OperationHandled(
                                        this,
                                        new ConnectionEventArgs(
                                            $"Регистрация пользователя {datagram.UserLogin} прошла успешно",
                                            new Datagram(
                                                "server",
                                                datagram.Token,
                                                "success",
                                                "registration",
                                                sessionID),
                                            package.address,
                                            _timer.ElapsedMilliseconds));
                                }
                                else
                                {
                                    OperationHandled(
                                        this,
                                        new ConnectionEventArgs(
                                            $"Во время регистрации пользователя {datagram.UserLogin} возникли ошибки!",
                                            new Datagram("server", datagram.Token, "used", "login", null),
                                            package.address,
                                            _timer.ElapsedMilliseconds));
                                }

                                break;
                            }

                        case "authentication" when datagram.Data is string password:
                            {
                                Guid newToken = _userBase.Authentication(datagram.UserLogin, password);
                                if (newToken != Guid.Empty)
                                {
                                    OperationHandled(
                                        this,
                                        new ConnectionEventArgs(
                                            $"Сессия пользователя {datagram.UserLogin} успешно обновлена",
                                            new Datagram(
                                                "server",
                                                datagram.Token,
                                                "success",
                                                "authentication",
                                                newToken),
                                            package.address,
                                            _timer.ElapsedMilliseconds));
                                }
                                else
                                {
                                    OperationHandled(
                                        this,
                                        new ConnectionEventArgs(
                                            $"Во время обновления сессии пользователя {datagram.UserLogin} возникли ошибки!",
                                            new Datagram("server", datagram.Token, "error", "authentication", null),
                                            package.address,
                                            _timer.ElapsedMilliseconds));
                                }

                                break;
                            }

                        case "check" when datagram.Data is string login:
                            {
                                OperationHandled(
                                    this,
                                    new ConnectionEventArgs(
                                        $"Запрос на доступность логина {login}",
                                        new Datagram(
                                            "server",
                                            Guid.Empty,
                                            _userBase.GetUser(login) == null ? "free" : "busy",
                                            "login",
                                            null),
                                        package.address,
                                        _timer.ElapsedMilliseconds));
                                break;
                            }
                    }
                }
            }

            _timer.Reset();
        }
    }
}
