
namespace ServerSide.UserManagement
{
    using System;
    using System.Collections.Generic;

    using ServerSide.Mapping;

    public class UserBase
    {
        private List<IPerson> _users = new List<IPerson>();

        public UserBase()
        {
            Action += InformFollowers;
        }

        public event PersonEventHandler Action = delegate { };

        public void Add(IPerson person)
        {
            if (!_users.Contains(person))
            {
                _users.Add(person);
            }
        }

        public void Remove(IPerson person)
        {
            if (_users.Contains(person))
            {
                _users.Remove(person);
            }
        }

        public void ChangeUserInfo(Guid personID, List<(string attribute, string value)> data)
        {
            if (_users.Find(x => x.ID == personID) is Person person)
            {
                var args = new PersonEventArgs(
                    "изменил" + (person.Gender == Gender.Female ? "а" : string.Empty),
                    DateTime.Now);
                foreach (var tuple in data)
                {
                    switch (tuple.attribute.ToLower())
                    {
                        case "name":
                            {
                                args.Info += $" имя на {tuple.value}";
                                Action(person, args);
                                person.Name = tuple.value;
                                break;
                            }

                        case "surname":
                            {
                                args.Info += $" фамилию на {tuple.value}";
                                Action(person, args);
                                person.Surname = tuple.value;
                                break;
                            }

                        case "patronomyc":
                            {
                                args.Info += $" отчество на {tuple.value}";
                                Action(person, args);
                                person.Patronymcic = tuple.value;
                                break;
                            }

                        case "birthday":
                            {
                                args.Info += $" день рождения на {tuple.value}";
                                Action(person, args);
                                person.BirthDate = Mapper.StringToDate(tuple.value);
                                break;
                            }

                        case "gender":
                            {
                                args.Info += $" пол на {tuple.value}";
                                Action(person, args);
                                person.Gender = (Gender)int.Parse(tuple.value);
                                break;
                            }

                        case "status":
                            {
                                args.Info += $" статус на {Mapper.MaritalToString(tuple.value)}";
                                Action(person, args);
                                person.MaritalStatus = (MaritalStatus)int.Parse(tuple.value);
                                break;
                            }

                        case "age":
                            {
                                args.Info += $" возраст на {Mapper.GenderToString(tuple.value)}";
                                Action(person, args);
                                person.Age = int.Parse(tuple.value);
                                break;
                            }

                        case "school":
                            {
                                args.Info += $" школа на {tuple.value}";
                                Action(person, args);
                                person.School = tuple.value;
                                break;
                            }

                        case "university":
                            {
                                args.Info += $" университет на {tuple.value}";
                                Action(person, args);
                                person.University = tuple.value;
                                break;
                            }
                    }
                }
            }
        }

        public void ChangeUserFriend(Guid personID, string action, Guid friendID)
        {
            IPerson person = _users.Find(x => x.ID == personID);
            IPerson friend = _users.Find(x => x.ID == friendID);
            if (person != null && friend != null)
            {
                if (action == "add")
                {
                    var args = new PersonEventArgs(
                        person.ToString() + " добавил" + (person.Gender == Gender.Female ? "а" : string.Empty),
                        DateTime.Now);
                    args.Info += " в друзья " + friend.ToString();
                    Action(person, args);
                    person.AddFriend(friend);
                    friend.GetFollower(person);
                }
                else
                {
                    var args = new PersonEventArgs(
                        person.ToString() + " убрал" + (person.Gender == Gender.Female ? "а" : string.Empty),
                        DateTime.Now);
                    args.Info += " из друзей " + friend.ToString();
                    Action(person, args);
                    person.RemoveFriend(friend);
                    friend.LoseFollower(person);
                }
            }
        }

        public void CreateNews(Guid personID, string action, string info, object value)
        {
            if (_users.Find(x => x.ID == personID) is Person person)
            {
                var args = new PersonEventArgs(
                    person.ToString() + " добавил" + (person.Gender == Gender.Female ? "а" : string.Empty),
                    DateTime.Now);
                switch (action)
                {
                    case "image":
                        {
                            args.Info += " картинку " + info;
                            Action(person, args);
                            person.AddNews(info, value, DateTime.Now);
                            break;
                        }

                    case "message":
                        {
                            args.Info += "  сообщение " + info;
                            Action(person, args);
                            person.AddNews(info, value, DateTime.Now);
                            break;
                        }
                }
            }
        }

        private static void InformFollowers(object sender, PersonEventArgs args)
        {
            if (sender is IPerson person)
            {
                foreach (IPerson follower in person.Followers)
                {
                    follower.AddNews(args.Info, null, args.OperationTime);
                }
            }
        }
    }
}