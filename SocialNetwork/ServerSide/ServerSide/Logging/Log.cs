
namespace ServerSide.Logging
{
    using System;
    using System.IO;
    using System.Text;

    using ServerSide.Interfaces;
    using ServerSide.Servicing;
    using ServerSide.Connecting;
    using ServerSide.Timing;

    public class Log : ILog, IProcess
    {
        private readonly string _filePath;

        private int _recordCount;

        private StreamWriter _fileWriter;

        private bool _isActive;

        public Log()
        {
            _filePath = "Logs\\";
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }

            int logNumber = Directory.GetFiles(_filePath, "*.txt").Length; //+ 1;
            while (!File.Exists(_filePath + $"{logNumber:D5}" + ".txt"))
            {
                logNumber++;
            }

            _filePath += $"{logNumber:D5}" + ".txt";

            FileStream file = File.Create(_filePath);
            file.Close();
        }

        public bool IsActive => _isActive;

        public void Start()
        {
            _recordCount = 1;
            _fileWriter = new StreamWriter(_filePath);
            Write("Событие: Логирование запущено\n");
            _isActive = true;
        }

        public void End()
        {
            Write("Событие: Логирование завершено\n");
            _fileWriter.Close();
            _isActive = false;
        }

        public void MakeRecord(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder(1024);
            switch (true)
            {
                case true when sender is IServer:
                    {
                        var server = (IServer)sender;
                        var eventInfo = (ServerEventArgs)e;
                        message.AppendLine($"Событие: {eventInfo.OperationInfo}");

                        break;
                    }

                case true when sender is IConnectionHandler:
                    {
                        var connectionHandler = (IConnectionHandler)sender;
                        var eventInfo = (ServerEventArgs)e;
                        
                        if (eventInfo.GetAddress != null)
                        {
                            message.AppendLine($"Операция: {eventInfo.OperationInfo}");
                            message.AppendLine($"Адрес отправителя: {eventInfo.GetAddress}");
                            message.AppendLine($"Вес сообщения: {eventInfo.DataSize / 1024.0:F4} кб.");
                            message.AppendLine($"Время обработки: {eventInfo.HandlingTime / 1000.0} сек.");
                        }
                        else
                        {
                            message.AppendLine($"Событие: {eventInfo.OperationInfo}");
                            if (connectionHandler.IsActive)
                            {
                                message.AppendLine($"Адрес модуля: {connectionHandler.Address}");
                                message.AppendLine($"Размер буфера данных: {connectionHandler.BufferSize / 1024.0:F4} кб.");
                                message.AppendLine($"Размер стека для обработки запросов: {connectionHandler.MaxCountConnections}");
                            }
                        }
                        
                        break;
                    }

                case true when sender is ITimeObserver:
                    {
                        var eventInfo = (TimeEventArgs)e;
                        if (eventInfo.IsNewDay)
                        {
                            message.AppendLine("Событие новый день");
                        }
                        else
                        {
                            message.AppendLine($"Событие: {eventInfo.OperationInfo}");
                        }

                        break;
                    }

                default:
                    {
                        message.AppendLine("Событие: Не удалось распознать событие");
                        message.AppendLine($"Отправитель: {sender}");
                        message.AppendLine($"Мета события: {e}");
                        break;
                    }
            }

            Write(message.ToString());
        }

        public void Write(string data)
        {
            StringBuilder record = new StringBuilder(1024);
            record.AppendLine($"Номер лога #{_recordCount++}");
            record.AppendLine($"Дата лога: {DateTime.Now}");
            record.AppendLine(data);
            _fileWriter.Write(record);
            Console.Write(record);
        }
    }

}