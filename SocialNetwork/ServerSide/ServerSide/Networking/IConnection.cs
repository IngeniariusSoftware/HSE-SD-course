
namespace ServerSide.Networking
{
    using ServerSide.Processing;

    public interface IConnection : IProcess
    {
        event ConnectionEventHandler OperationHandled;
    }
}