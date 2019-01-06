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
            Console.Title = "Сервер";
            Server server = new Server(IPAddress.Any, 904, 10500000, 10000);
            server.Start();
            Console.WriteLine("Серверный процесс запущен\n");
            server.Manage();
            while (server.IsWorked || server.log.IsWorked) ;
            Console.WriteLine("\nДля завершения работы нажмите любую клавишу");
            Console.ReadKey(true);
        }
    }
}
