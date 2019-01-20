
namespace ServerSide.UserManagement
{
    using System;
    using System.Collections.Generic;

    using ServerSide.UserManagement.Journaling;

    public interface IPerson
    {
        string Name { get; }

        string Surname { get; }

        string Patronymcic { get; }

        DateTime BirthDate { get; }

        Gender Gender { get; }

        MaritalStatus MaritalStatus { get; }

        string University { get; }

        string School { get; }

        int Age { get; }

        Guid ID { get; }

        List<IPerson> Friends { get; }

        List<IPerson> Followers { get; }

        IJournal Journal { get; }

        void AddFriend(IPerson person);

        void RemoveFriend(IPerson person);

        void GetFollower(IPerson person);

        void LoseFollower(IPerson person);

        void AddNews(string info, object value, DateTime time);

        string ToString();
    }
}
