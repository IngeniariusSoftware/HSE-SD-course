
namespace ServerSide.Logging
{
    using System;

    using ServerSide.Processing;

    public interface ILog : IProcess
    {
        event ProcessEventHandler OperationCompleted;

        void AddRecord(object sender, EventArgs e);
    }
}