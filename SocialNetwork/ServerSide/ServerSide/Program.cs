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

    class Program
    {
        private static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, 904));
            socket.Listen(10000);
            var buffer = new byte[10500000];

            Console.WriteLine("Сервер запущен. Ожидание подключений...");
            int messageCount = 1;
            Stopwatch timer = new Stopwatch();

            while (true)
            {
                Socket client = socket.Accept();

                int size;
                do
                {
                    size = client.Receive(buffer);
                    if (!timer.IsRunning)
                    {
                        timer.Start();
                    }
                }
                while (client.Available > 0);

                Console.WriteLine("\nНомер сообщения: {0}", messageCount);
                Console.WriteLine("Дата сообщения: {0}", DateTime.Now);
                Console.WriteLine("Отправитель: {0}", client.LocalEndPoint);
                Console.WriteLine("Сообщение: ");
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, size));
                Console.WriteLine("Время обработки: {0}", timer.ElapsedMilliseconds / 1000.0);
                timer.Reset();
                messageCount++;
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
    }
}
