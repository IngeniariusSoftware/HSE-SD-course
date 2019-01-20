
namespace ServerSide.UserManagement.Journaling
{
    using System;

    public class Record : IRecord
    {
        public Record(string info, object value, DateTime time)
        {
            Info = info;
            Value = value;
            CreatingTime = time;
        }

        public Record(string info, object value)
        {
            Info = info;
            Value = value;
            CreatingTime = DateTime.Now;
        }

        public DateTime CreatingTime { get; }

        public string Info { get; }

        public object Value { get; }
    }
}
