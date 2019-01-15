
namespace ServerSide
{
    using System;
    using System.Net;
    using System.Net.Sockets;

    using ServerSide.Logging;
    using ServerSide.Servicing;

    class Program
    {
        private static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main()
        {
            Console.Title = "Сервер";

            var log = new Log();
            log.Start();

            Server server = new Server(IPAddress.Any, 904, 10500000, 10000, log);
            server.Start();

            log.End();

            //var crypter = new Encryptor("Server", log);
            //var messageHandler = new MessageHandler(8, 8, 64, 16, crypter);


            Console.WriteLine("\nДля завершения работы нажмите любую клавишу");
            Console.ReadKey(true);
        }
    }
}