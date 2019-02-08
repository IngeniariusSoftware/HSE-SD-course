
namespace ServerSide.Processing
{
    using System;

    public delegate void ProcessEventHandler(object sender, ProcessEventArgs e);

    public class ProcessEventArgs : EventArgs
    {
        public ProcessEventArgs(string operationInfo)
        {
            OperationInfo = operationInfo;
        }

        public ProcessEventArgs(string operationInfo, object data)
        {
            OperationInfo = operationInfo;
            Data = data;
        }

        public string OperationInfo { get; set; }

        public object Data { get; set; }
    }
}