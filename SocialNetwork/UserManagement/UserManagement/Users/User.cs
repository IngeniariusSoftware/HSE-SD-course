
namespace UserManagement.Users
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;

    using UserManagement.Journaling;

    [Serializable]
    public class User : IUser
    {
        private Regex nameRegex = new Regex("^[A-Za-zА-Яа-я ]{0,25}$");

        private Regex loginRegex = new Regex("^[A-Za-zА-Яа-я0-9 ]{0,25}$");

        private Regex educationRegex = new Regex("^[A-Za-zА-Яа-я0-9№ ]{0,25}$");

        private List<IUser> _friends = new List<IUser>();

        private List<IUser> _followers = new List<IUser>();

        private IJournal _journal = new Journal();

        public User(
            string login,
            string name,
            string surname,
            string patronymic,
            DateTime birthDate,
            Gender gender,
            MaritalStatus maritalStatus,
            string university,
            string school,
            string password = null,
            Bitmap avatar = null)
        {
            Login = login;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Gender = gender;
            MaritalStatus = maritalStatus;
            University = university;
            School = school;
            Password = password;
            Avatar = avatar;
        }

        public Bitmap Avatar { get; set; }

        private string _login;

        private string _name;

        private string _surname;

        private string _patronymic;

        private string _university;

        private string _school;

        public string Login
        {
            get => _login;

            set
            {
                if (loginRegex.IsMatch(value))
                {
                    _login = value;
                }
            }
        }

        public string Name
        {
            get => _name;

            set
            {
                if (nameRegex.IsMatch(value))
                {
                    _name = value;
                }
            }
        }

        public string Surname
        {
            get => _surname;

            set
            {
                if (nameRegex.IsMatch(value))
                {
                    _surname = value;
                }
            }
        }

        public string Patronymic
        {
            get => _patronymic;

            set
            {
                if (nameRegex.IsMatch(value))
                {
                    _patronymic = value;
                }
            }
        }

        public string University
        {
            get => _university;

            set
            {
                if (educationRegex.IsMatch(value))
                {
                    _university = value;
                }
            }
        }

        public string School
        {
            get => _school;

            set
            {
                if (educationRegex.IsMatch(value))
                {
                    _school = value;
                }
            }
        }

        public string FullName => $"{Name} {Surname} {Patronymic}";

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public int Age => DateTime.Today.Year - BirthDate.Year;

        public string Password { get; set; }

        public IJournal Journal => _journal;

        public List<IUser> Friends => _friends;

        public List<IUser> Followers => _followers;

        public List<string> FindDifference(IUser user)
        {
            var attributes = new List<string>();
            if (Name != user.Name && !string.IsNullOrEmpty(user.Name))
            {
                attributes.Add("Name");
            }

            if (Surname != user.Surname && !string.IsNullOrEmpty(user.Surname))
            {
                attributes.Add("Surname");
            }

            if (Patronymic != user.Patronymic && !string.IsNullOrEmpty(user.Patronymic))
            {
                attributes.Add("Patronymic");
            }

            if (BirthDate != user.BirthDate)
            {
                attributes.Add("BirthDay");
            }

            if (Gender != user.Gender)
            {
                attributes.Add("Gender");
            }

            if (MaritalStatus != user.MaritalStatus)
            {
                attributes.Add("Status");
            }

            if (University != user.University && !string.IsNullOrEmpty(user.University))
            {
                attributes.Add("University");
            }

            if (School != user.School && !string.IsNullOrEmpty(user.School))
            {
                attributes.Add("School");
            }

            if (Age != user.Age)
            {
                attributes.Add("Age");
            }

            if (Avatar != user.Avatar)
            {
                attributes.Add("Avatar");
            }

            return attributes;
        }

        public bool AddFriend(IUser user)
        {
            if (Login != user.Login && !_friends.Contains(user))
            {
                _friends.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveFriend(IUser user)
        {
            if (_friends.Contains(user))
            {
                _friends.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetFollower(IUser user)
        {
            if (!_followers.Contains(user))
            {
                _followers.Add(user);
            }
        }

        public void LoseFollower(IUser user)
        {
            if (_followers.Contains(user))
            {
                _followers.Remove(user);
            }
        }

        public void AddNews(Record record)
        {
            _journal.Add(record);
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}