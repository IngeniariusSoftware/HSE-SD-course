
namespace ServerSide.Logging
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading;

    using ServerSide.Handling;
    using ServerSide.Networking;
    using ServerSide.Processing;
    using ServerSide.Servicing;

    using UserManagement.Users;

    public class Log : ILog
    {
        private readonly EventWaitHandle _recordAdded = new AutoResetEvent(false);

        private readonly EventWaitHandle _recordRemoved = new AutoResetEvent(false);

        private readonly EventWaitHandle _isEnd = new AutoResetEvent(false);

        private readonly object _locker = new object();

        private readonly string _filePath;

        private int _sizeRecordQueue;

        private int _recordCount;

        private StreamWriter _fileWriter;

        private Queue<(object sender, EventArgs e)> _records;

        private StringBuilder _buffer = new StringBuilder(1024);

        public Log(int sizeRecordQueue)
        {
            _sizeRecordQueue = sizeRecordQueue;
            _records = new Queue<(object sender, EventArgs e)>(sizeRecordQueue);
            _filePath = "Logs\\";
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }

            int logNumber = Directory.GetFiles(_filePath, "*.txt").Length + 1;
            while (File.Exists(_filePath + $"{logNumber:D5}" + ".txt"))
            {
                logNumber++;
            }

            _filePath += $"{logNumber:D5}" + ".txt";

            FileStream file = File.Create(_filePath);
            file.Close();
        }

        public event ProcessEventHandler StateChanged = delegate { };

        public event ProcessEventHandler OperationCompleted = delegate { };

        public bool IsActive { get; private set; }

        public int SizeMessageQueue
        {
            get => _sizeRecordQueue;

            set => _sizeRecordQueue = Math.Max(1, value);
        }

        public void Start()
        {
            if (!IsActive)
            {
                IsActive = true;
                _recordCount = 1;
                _fileWriter = new StreamWriter(_filePath);
                new Thread(Handling) { Name = "Поток логирования" }.Start();
                StateChanged(this, new ProcessEventArgs("Логирование запущено"));
            }
            else
            {
                OperationCompleted(this, new ProcessEventArgs("Модуль логирования уже включен!"));
            }
        }

        public void End()
        {
            if (IsActive)
            {
                IsActive = false;
                StateChanged(this, new ProcessEventArgs("Завершение логирования"));

                while (!_isEnd.WaitOne(100))
                {
                    OperationCompleted(this, new ProcessEventArgs("Ожидание завершение работы логирования..."));
                }
            }
            else
            {
                OperationCompleted(this, new ProcessEventArgs("Модуль логирования уже выключен!"));
            }
        }

        public void AddRecord(object sender, EventArgs e)
        {
            if (IsActive)
            {
                lock (_locker)
                {
                    if (_records.Count > _sizeRecordQueue)
                    {
                        OperationCompleted(this, new ProcessEventArgs("Очередь сообщений логирования переполнена!\n"));
                        _recordRemoved.WaitOne(100);
                    }

                    _records.Enqueue((sender, e));
                    _recordAdded.Set();
                }
            }
            else
            {
                OperationCompleted(this, new ProcessEventArgs("Модуль логирования отключен!\n"));
            }
        }

        private void Handling()
        {
            while (IsActive || _records.Count > 0)
            {
                _recordAdded.WaitOne(100);
                while (_records.Count > 0)
                {
                    var (sender, e) = _records.Dequeue();
                    _recordRemoved.Set();
                    HandleRecord(sender, e);
                }
            }

            _fileWriter.Close();
            _isEnd.Set();
        }

        private void HandleRecord(object sender, EventArgs e)
        {
            _buffer.Clear();
            _buffer.AppendLine($"Номер лога #{_recordCount++}");
            _buffer.AppendLine($"Дата лога: {DateTime.Now}");

            switch (true)
            {
                case true when sender is ILog log:
                    {
                        var eventInfo = (ProcessEventArgs)e;
                        _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                        _buffer.AppendLine("Отправитель: Модуль логирования");
                        _buffer.AppendLine($"Размер очереди для обработки логов: {_sizeRecordQueue}");
                        break;
                    }

                case true when sender is IServer server:
                    {
                        var eventInfo = (ProcessEventArgs)e;
                        _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                        _buffer.AppendLine("Отправитель: Сервер");
                        _buffer.AppendLine($"Адрес сервера: {server.Address}");
                        _buffer.AppendLine($"Размер буфера данных: {server.BufferSize / 1024.0:F4} кб.");
                        _buffer.AppendLine(
                            $"Максимальное количество одновременных подключений: {server.MaxCountConnections}");
                        break;
                    }

                case true when sender is IMessageHandler messageHandler:
                    {
                        switch (true)
                        {
                            case true when e is ConnectionEventArgs eventInfo:
                                {
                                    _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                                    _buffer.AppendLine("Отправитель: Модуль обработки сообщений");
                                    _buffer.AppendLine($"Время обработки операции: {eventInfo.ProcessingTime} мс.");
                                    break;
                                }

                            case true when e is ProcessEventArgs eventInfo:
                                {
                                    _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                                    _buffer.AppendLine("Отправитель: Модуль обработки сообщений");
                                    _buffer.AppendLine(
                                        $"Размер очереди для обработки запросов: {messageHandler.SizePackageQueue}");
                                    break;
                                }
                        }

                        break;
                    }

                case true when sender is UserBase userBase:
                    {
                        var eventInfo = (ProcessEventArgs)e;
                        _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                        _buffer.AppendLine("Отправитель: База пользователей");
                        break;
                    }

                case true when sender is ConnectionReceiver connectionHandler:
                    {
                        switch (true)
                        {
                            case true when e is ConnectionEventArgs eventInfo:
                                {
                                    _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                                    _buffer.AppendLine("Отправитель: Модуль обработки подключений");
                                    _buffer.AppendLine($"Пользователь отправитель: {eventInfo.Address}");
                                    _buffer.AppendLine(
                                        $"Тип сообщения: {((byte[])eventInfo.Data).Length / 1024.0:F4} кб.");
                                    break;
                                }

                            case true when e is ProcessEventArgs eventInfo:
                                {
                                    _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                                    _buffer.AppendLine("Отправитель: Модуль обработки подключений");
                                    _buffer.AppendLine(
                                        $"Размер буфера данных: {connectionHandler.BufferSize / 1024.0:F4} кб.");
                                    _buffer.AppendLine(
                                        $"Максимальное количество одновременных подключений: {connectionHandler.MaxCountConnections}");
                                    break;
                                }
                        }

                        break;
                    }

                case true when sender is ConnectionSender connectionSender:
                    {
                        switch (true)
                        {
                            case true when e is ConnectionEventArgs eventInfo:
                                {
                                    _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                                    _buffer.AppendLine("Отправитель: Модуль отправки сообщений");
                                    break;
                                }

                            case true when e is ProcessEventArgs eventInfo:
                                {
                                    _buffer.AppendLine($"Событие: {eventInfo.OperationInfo}");
                                    _buffer.AppendLine("Отправитель: Модуль отправки сообщений");
                                    _buffer.AppendLine(
                                        $"Размер очереди для обработки запросов: {connectionSender.SizePackageQueue}");
                                    break;
                                }
                        }

                        break;
                    }

                case true when sender is IUser person:
                    {
                        var eventInfo = (UserEventArgs)e;
                        _buffer.AppendLine($"Событие: {eventInfo.Info}");
                        _buffer.AppendLine($"Отправитель: Пользователь {person}");
                        break;
                    }

                default:
                    {
                        _buffer.AppendLine("Событие: Не удалось распознать событие");
                        _buffer.AppendLine($"Отправитель: {sender}");
                        _buffer.AppendLine($"Информация о событии: {e}");
                        break;
                    }
            }

            _fileWriter.WriteLine(_buffer);
            OperationCompleted(this, new ProcessEventArgs(_buffer.ToString()));
        }
    }
}