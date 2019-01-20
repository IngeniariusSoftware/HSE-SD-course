
namespace ServerSide.UserManagement.Journaling
{
    using System.Collections.Generic;

    public class Journal : IJournal
    {
        private List<IRecord> _news;

        public List<IRecord> News => _news;

        public void Add(IRecord record)
        {
            _news.Add(record);
        }

        public void Remove(IRecord record)
        {
            _news.Remove(record);
        }
    }
}