using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    using System.IO;
    using System.Net.Sockets;

    public class Log
    {
        private string logPath;

        private int logCount = 0;

        private StreamWriter logWriter;

        private StringBuilder info;

        public bool isWorked;

        public Log()
        {
            logPath = "Logs\\";
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            int logNumber = Directory.GetFiles(logPath, "*.txt").Length + 1;
            while (File.Exists(logPath + $"{logNumber:D5}" + ".txt"))
            {
                logNumber++;
            }

            logPath += $"{logNumber:D5}" + ".txt";

            FileStream file = File.Create(logPath);
            file.Close();
        }

        public void StartLogging()
        {
            logCount = 1;
            info = new StringBuilder(1024);
            logWriter = new StreamWriter(logPath);
            MakeLog("Логирование запущено");
            isWorked = true;
        }

        public void EndLogging()
        {
            MakeLog("Сервер выключен\nЛогирование завершено");
            logWriter.Close();
            isWorked = false;
        }

        public void MakeLog(string message)
        {
            info.Append($"\nНомер лога #{logCount++}\n");
            info.Append($"Дата лога: {DateTime.Now}\n");
            info.Append(message);
            logWriter.WriteLine(info);
            Console.WriteLine(info);
            info.Clear();
        }

        public void MakeLogServerInfo(Socket socket, bool isWorked, int bufferLength, int maxCountConnections)
        {
            StringBuilder message = new StringBuilder(1024);
            if (socket != null)
            {
                message.Append(
                    isWorked ? "Состояние: включен\nОжидание подключений\n" : "Сервер создан\nСостояние: выключен\n");
                message.Append($"Сокет: {socket.LocalEndPoint}\n");
                message.Append($"Размер буфера данных: {bufferLength / 1024.0} кб.\n");
                message.Append($"Размер стека для обработки запросов: {maxCountConnections}");
            }
            else
            {
                message.Append("Сервер не создан");
            }

            MakeLog(message.ToString());
        }

        public void MakeLogOperationInfo(Socket socket, double messageSize, double operationTime)
        {
            StringBuilder message = new StringBuilder(1024);
            message.Append($"Сокет: {socket.LocalEndPoint}\n");
            message.Append($"Вес сообщения: {messageSize} кб.\n");
            message.Append($"Время обработки: {operationTime} сек.\n");
            MakeLog(message.ToString());
        }
    }
}