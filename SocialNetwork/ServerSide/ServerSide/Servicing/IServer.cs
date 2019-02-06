
namespace ServerSide.Servicing
{
    using System.Net;

    using ServerSide.Logging;
    using ServerSide.Processing;

    internal interface IServer : IProcess
    {
        event ProcessEventHandler ModuleChangeState;

        IPEndPoint Address { get; }

        int BufferSize { get; }

        int MaxCountConnections { get; }

        ILog Log { get; }

        string Manage(string command);

        void Subscribing();
    }
}