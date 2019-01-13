
namespace ServerSide.Servicing
{
    using System;
    using System.Net;

    public delegate void ServerEventHandler(object sender, ServerEventArgs e);

    public class ServerEventArgs : EventArgs
    {
        private IPEndPoint _address;

        private double _dataSize;

        private double _handlingTime;

        private string _operationInfo;

        public ServerEventArgs(string operationInfo)
        {
            _operationInfo = operationInfo;
        }

        public ServerEventArgs(IPEndPoint address, double dataSize, double handlingTime, string operationInfo)
        {
            _address = address;
            _dataSize = dataSize;
            _handlingTime = handlingTime;
            _operationInfo = operationInfo;
        }

        public IPEndPoint GetAddress => _address;

        public double DataSize => _dataSize;

        public double HandlingTime => _handlingTime;

        public string OperationInfo => _operationInfo;
    }
}