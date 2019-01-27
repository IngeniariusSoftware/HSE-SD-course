
namespace UserManagement.Users
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using UserManagement.Journaling;

    public interface IUser
    {
        Bitmap Avatar { get; set; }

        string Login { get; set; }

        string Password { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        string Patronymic { get; set; }

        string FullName { get; }

        DateTime BirthDate { get; set; }

        Gender Gender { get; set; }

        MaritalStatus MaritalStatus { get; set; }

        string University { get; set; }

        string School { get; set; }

        int Age { get; }

        List<IUser> Friends { get; }

        List<IUser> Followers { get; }

        IJournal Journal { get; }

        List<string> FindDifference(IUser user);

        bool AddFriend(IUser user);

        bool RemoveFriend(IUser user);

        void GetFollower(IUser user);

        void LoseFollower(IUser user);

        void AddNews(Record record);

        string ToString();
    }
}