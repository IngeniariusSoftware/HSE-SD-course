
namespace ServerSide.Networking
{
    using System.Net;

    using ServerSide.Processing;

    public delegate void ConnectionEventHandler(object sender, ConnectionEventArgs e);

    public class ConnectionEventArgs : ProcessEventArgs
    {
        public ConnectionEventArgs(string operationInfo, object data, IPEndPoint address, double processingTime = 0)
            : base(operationInfo, data)
        {
            Address = address;
            ProcessingTime = processingTime;
        }

        public IPEndPoint Address { get; }

        public double ProcessingTime { get; }
    }
}