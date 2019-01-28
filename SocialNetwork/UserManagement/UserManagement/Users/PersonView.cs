
namespace UserManagement.Users
{
    using System;
    using System.Drawing;

    [Serializable]
    public class PersonView
    {
        public PersonView(string login, string fullName, Bitmap avatar = null)
        {
            Login = login;
            FullName = fullName;
            Avatar = avatar;
        }

        public string Login { get; set; }

        public string FullName { get; set; }

        public Bitmap Avatar { get; set; }
    }
}