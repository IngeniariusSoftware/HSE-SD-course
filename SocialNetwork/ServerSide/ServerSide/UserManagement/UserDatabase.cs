
namespace ServerSide.UserManagement
{
    using System;
    using System.Collections.Generic;

    using ServerSide.Persons;

    public class UserBase
    {
        private List<IPerson> _users = new List<IPerson>();

        public event PersonEventHandler Action = delegate { };

        public event fvere BirthDayBecome = delegate { };

        public int Add(Person person)
        {
            _users.Add(person);
        }

        public void Remove()
        {

        }

        public void ChangeUserData()
        {

        }
    }
}
