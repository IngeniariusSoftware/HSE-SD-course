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

        private bool isWorked;

        public bool IsWorked => isWorked;

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
            logWriter.WriteLine($"Логирование запущено\nДата запуска: {DateTime.Now}");
            isWorked = true;
        }
        
        public void EndLogging()
        {
            Console.WriteLine($"Сервер выключен\nЛогирование завершено\nДата завершения: {DateTime.Now}");
            logWriter.WriteLine($"Сервер выключен\nЛогирование завершено\nДата завершения: {DateTime.Now}");
            logWriter.Close();
            isWorked = false;
        }

        public void MakeLog(string message)
        {
            info.Append($"\nНомер лога #{logCount++}\n");
            info.Append(message);
            logWriter.WriteLine(info);
            Console.WriteLine(info);
            info.Clear();
        }

        public void MakeLogServerInfo(Socket socket, bool isWorked, int bufferLength, int maxCountConnections)
        {
            info.Append($"\nНомер лога #{logCount++}\n");
            if (socket != null)
            {
                info.Append(isWorked ? "Состояние: включен\nОжидание подключений\n" : "Сервер создан\nСостояние: выключен\n");
                info.Append($"Сокет: {socket.LocalEndPoint}\n");
                info.Append($"Время: {DateTime.Now}\n");
                info.Append($"Размер буфера данных: {bufferLength / 1024.0} кб.\n");
                info.Append($"Размер стека для обработки запросов: {maxCountConnections}\n");
            }
            else
            {
                info.Append("\tСервер не создан\n");
                info.Append($"Время: {DateTime.Now}");
            }

            logWriter.WriteLine(info);
            Console.WriteLine(info);
            info.Clear();
        }

        public void MakeLogOperationInfo(Socket socket, double messageSize,double operationTime)
        {
            info.Append($"Номер лога #{logCount++}\n");
            info.Append($"Дата сообщения: {DateTime.Now}\n");
            info.Append($"Отправитель: {socket.LocalEndPoint}\n");
            info.Append($"Вес сообщения: {messageSize} кб.\n");
            info.Append($"Время обработки: {operationTime} сек.\n");
            logWriter.WriteLine(info);
            Console.WriteLine(info);
            info.Clear();
        }
    }
}
