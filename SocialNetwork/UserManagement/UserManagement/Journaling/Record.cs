
namespace UserManagement.Journaling
{
    using System;

    [Serializable]
    public class Record : IRecord
    {
        public Record(string fullName, object value)
        {
            FullName = fullName;
            Value = value;
            CreatingTime = DateTime.Now;
        }

        public Record(string fullName, string info, object value)
        {
            FullName = fullName;
            Info = info;
            Value = value;
            CreatingTime = DateTime.Now;
        }

        public Record(string fullName, string info, object value, DateTime time)
        {
            FullName = fullName;
            Info = info;
            Value = value;
            CreatingTime = time;
        }

        public string FullName { get; }

        public string Info { get; }

        public object Value { get; }

        public DateTime CreatingTime { get; }
    }
}