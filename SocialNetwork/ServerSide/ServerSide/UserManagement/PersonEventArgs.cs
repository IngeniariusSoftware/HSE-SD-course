
namespace ServerSide.UserManagement
{
    using System;

    public delegate void PersonEventHandler(object sender, PersonEventArgs e);

    public class PersonEventArgs : EventArgs
    {
        public PersonEventArgs(string operationInfo)
        {
            OperationInfo = operationInfo;
        }

        public string OperationInfo { get; }
    }
}