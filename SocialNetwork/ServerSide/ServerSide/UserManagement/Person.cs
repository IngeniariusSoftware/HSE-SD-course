
namespace ServerSide.UserManagement
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using ServerSide;
    using ServerSide.UserManagement.Journaling;

    public class Person : IPerson
    {
        private List<IPerson> _friends = new List<IPerson>();

        private List<IPerson> _followers = new List<IPerson>();

        private IJournal _journal;

        private Timer _birth;

        private event PersonEventHandler BirthDay;

       public Person(
            string name,
            string surname,
            string patronomyc,
            DateTime birthDate,
            Gender gender,
            MaritalStatus maritalStatus,
            string university,
            string school,
            int age)
       {
           long timeToBirth;
           if (DateTime.Now > BirthDate.Date)
           {
               timeToBirth = (long)(DateTime.Now - BirthDate.Date).TotalMilliseconds;
           }
           else
           {
               timeToBirth = (long)(DateTime.Now - BirthDate.Date.AddYears(1)).TotalMilliseconds;
           }

           _birth = new Timer(new TimerCallback(Birth), this, timeToBirth, 60000);
            Name = name;
            Surname = surname;
            Patronymcic = patronomyc;
            BirthDate = birthDate;
            Gender = gender;
            MaritalStatus = maritalStatus;
            University = university;
            School = school;
            Age = age;
            ID = Guid.NewGuid();
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymcic { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public string University { get; set; }

        public string School { get; set; }

        public int Age { get; set; }

        public Guid ID { get; }

        public IJournal Journal => _journal;

        public List<IPerson> Friends => _friends;

        public List<IPerson> Followers => _followers;

        public void AddFriend(IPerson person)
        {
            if (!_friends.Contains(person))
            {
                _friends.Add(person);
            }
        }

        public void RemoveFriend(IPerson person)
        {
            if (_friends.Contains(person))
            {
                _friends.Add(person);
            }
        }

        public void GetFollower(IPerson person)
        {
            if (!_followers.Contains(person))
            {
                _followers.Add(person);
            }
        }

        public void LoseFollower(IPerson person)
        {
            if (_followers.Contains(person))
            {
                _followers.Remove(person);
            }
        }

        public void AddNews(string info, object value, DateTime time)
        {
            _journal.Add(new Record(info, value, time));
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public void Birth(object obj)
        {
            _birth.Change((long)(DateTime.Now - BirthDate.Date.AddYears(1)).TotalMilliseconds, 60000);
            BirthDay(null, null);
        }
    }
}