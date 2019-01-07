namespace ServerSide
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    class Program
    {
        private static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main()
        {
            var log = new Log();
            log.StartLogging();
            var crypter = new Crypter("Server", log);
            var messageHandler = new MessageHandler(crypter);
            Console.Title = "Сервер";
            Server server = new Server(IPAddress.Any, 904, 10500000, 10000, log, messageHandler);
            server.Start();
            log.MakeLog("Серверный процесс запущен");
            server.Manage();
            while (log.isWorked) ;
            crypter.Close();
            log.EndLogging(); 
            Console.WriteLine("\nДля завершения работы нажмите любую клавишу");
            Console.ReadKey(true);
        }
    }
}
