
namespace UserManagement.Users
{
    using System;

    public delegate void UserEventHandler(object sender, UserEventArgs e);

    public class UserEventArgs : EventArgs
    {
        public UserEventArgs(string info, object value)
        {
            Info = info;
            Value = value;
        }

        public string Info { get; set; }

        public object Value { get; set; }
    }
}