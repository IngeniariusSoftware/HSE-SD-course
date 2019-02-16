
namespace ServerSide.Handling
{
    using ServerSide.Networking;
    using ServerSide.Processing;

    public interface IMessageHandler : IProcess
    {
        event ConnectionEventHandler OperationHandled;

        int SizePackageQueue { get; }

        void AddMessage(object sender, ConnectionEventArgs e);
    }
}