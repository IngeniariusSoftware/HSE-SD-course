
namespace UserManagement.Journaling
{
    using System.Collections.Generic;

    public interface IJournal
    {
        List<IRecord> News { get; }

        void Add(IRecord record);

        void Remove(IRecord record);
    }
}