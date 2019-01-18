
namespace ServerSide.Connecting
{
    using System.Net;

    using ServerSide.Interfaces;
    using ServerSide.Servicing;

    public interface IConnectionHandler : IProcess
    {
        event ServerEventHandler OperationHandled;

        bool IsActive { get; }

        double BufferSize { get; }

        int MaxCountConnections { get; }

        IPEndPoint Address { get; }
    }
}
