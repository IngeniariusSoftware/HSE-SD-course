
namespace ServerSide.UserManagement
{
    using System;

    public delegate void PersonEventHandler(object sender, PersonEventArgs e);

    public class PersonEventArgs : EventArgs
    {
        private string _info;

        public PersonEventArgs(string info, DateTime operationTime)
        {
            _info = info;
            OperationTime = operationTime;
        }

        public string Info { get; set; }

        public DateTime OperationTime { get; }
    }
}