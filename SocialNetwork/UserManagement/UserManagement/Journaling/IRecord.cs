
namespace UserManagement.Journaling
{
    using System;

    public interface IRecord
    {
        string FullName { get; }

        string Info { get; }

        object Value { get; }

        DateTime CreatingTime { get; }
    }
}