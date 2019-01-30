
namespace UserManagement.Journaling
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Journal : IJournal
    {
        private List<IRecord> _news = new List<IRecord>();

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