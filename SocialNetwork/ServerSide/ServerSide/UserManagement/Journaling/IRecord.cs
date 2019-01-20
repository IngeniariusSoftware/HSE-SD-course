
namespace ServerSide.UserManagement.Journaling
{
    using System;

    public interface IRecord
    {
        DateTime CreatingTime { get; }

        string Info { get; }

        object Value { get; }
    }
}
