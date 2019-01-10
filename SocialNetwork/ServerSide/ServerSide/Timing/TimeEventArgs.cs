
namespace ServerSide.Timing
{
    using System;

    public delegate void TimeEventHandler(object sender, TimeEventArgs e);

    public class TimeEventArgs : EventArgs
    {
        private bool _isNewDay;

        private string _operationInfo;

        public TimeEventArgs(string operationInfo)
        {
            _operationInfo = operationInfo;
        }

        public TimeEventArgs(bool isNewDay)
        {
            _isNewDay = isNewDay;
        }

        public string OperationInfo => _operationInfo;

        public bool IsNewDay => _isNewDay;
    }
}