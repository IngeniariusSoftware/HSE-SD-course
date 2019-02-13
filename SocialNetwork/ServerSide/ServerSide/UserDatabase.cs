
namespace ServerSide
{
    using System;
    using System.Collections.Generic;
    using System.Timers;

    using ServerSide.Mapping;
    using ServerSide.Processing;
    using ServerSide.Safety;

    using UserManagement;
    using UserManagement.Journaling;
    using UserManagement.Users;

    public class UserBase
    {
        private List<IUser> _users = new List<IUser>();

        private ProtectionModule _protectionModule;

        private Timer _timer;

        public UserBase()
        {
            Action += InformFollowers;
            BirthDay += InformFollowers;
            _protectionModule = new ProtectionModule();
            _timer = new Timer(24 * 60 * 60 * 1000);
            _timer.Elapsed += CheckBirthDays;
        }

        public event ProcessEventHandler OperationCompleted = delegate { };

        public event UserEventHandler Action = delegate { };

        public event UserEventHandler BirthDay = delegate { };

        public Guid AddUser(IUser user)
        {
            if (GetUser(user.Login) == null)
            {
                _users.Add(
                    new User(
                        user.Login,
                        user.Name,
                        user.Surname,
                        user.Patronymic,
                        user.BirthDate,
                        user.Gender,
                        user.MaritalStatus,
                        user.University,
                        user.School));
                Guid sessionID = _protectionModule.AddSession(user.Login, user.Password);
                CheckUserBirthDay(user);

                OperationCompleted(this, new ProcessEventArgs($"В базу добавлен новый пользователь: {user}"));
                return sessionID;
            }
            else
            {
                return Guid.Empty;
            }
        }

        public void RemoveUser(IUser user)
        {
            if (_users.Contains(user))
            {
                _users.Remove(user);
                OperationCompleted(this, new ProcessEventArgs($"Из базы был удален пользователь: {user}"));
            }
        }

        public object GetInformation(string login, string target)
        {
            IUser user = GetUser(login);
            if (user != null)
            {
                switch (target)
                {
                    case "friends":
                        {
                            OperationCompleted(
                                this,
                                new ProcessEventArgs($"Выдана информация о друзьях пользователя {user}"));

                            var friends = new List<PersonView>();
                            foreach (IUser friend in user.Friends)
                            {
                                friends.Add(new PersonView(friend.Login, friend.ToString(), friend.Avatar));
                            }

                            return friends;
                        }

                    case "followers":
                        {
                            OperationCompleted(
                                this,
                                new ProcessEventArgs($"Выдана информация о подписчиках пользователя {user}"));

                            var followers = new List<PersonView>();
                            foreach (IUser follower in user.Followers)
                            {
                                followers.Add(new PersonView(follower.Login, follower.ToString(), follower.Avatar));
                            }

                            return followers;
                        }

                    case "news":
                        {
                            OperationCompleted(
                                this,
                                new ProcessEventArgs($"Выдана информация о новостях пользователя {user}"));
                            return user.Journal;
                        }

                    case "user":
                        {
                            OperationCompleted(this, new ProcessEventArgs($"Выдана информация о пользователе {user}"));
                            return new User(
                                user.Login,
                                user.Name,
                                user.Surname,
                                user.Patronymic,
                                user.BirthDate,
                                user.Gender,
                                user.MaritalStatus,
                                user.University,
                                user.School,
                                null,
                                user.Avatar);
                        }

                    case "people":
                        {
                            OperationCompleted(
                                this,
                                new ProcessEventArgs($"Информация о всех людях выдана пользователю {user}"));
                            var people = new List<PersonView>();
                            foreach (IUser person in _users)
                            {
                                people.Add(new PersonView(person.Login, person.ToString(), person.Avatar));
                            }

                            return people;
                        }

                    default:
                        {
                            return null;
                        }
                }
            }
            else
            {
                return null;
            }
        }

        public bool UpdateUserInfo(IUser newUser)
        {
            IUser originalUser = GetUser(newUser.Login);
            if (originalUser != null)
            {
                foreach (string attribute in originalUser.FindDifference(newUser))
                {
                    var args = new UserEventArgs(
                        "Изменил" + (originalUser.Gender == Gender.Female ? "а" : string.Empty),
                        string.Empty);
                    switch (attribute.ToLower())
                    {
                        case "name":
                            {
                                args.Info += " имя на";
                                args.Value = newUser.Name;
                                Action(originalUser, args);
                                originalUser.Name = newUser.Name;
                                break;
                            }

                        case "surname":
                            {
                                args.Info += " фамилию";
                                args.Value = newUser.Surname;
                                Action(originalUser, args);
                                originalUser.Surname = newUser.Surname;
                                break;
                            }

                        case "patronymic":
                            {
                                args.Info += " отчество на";
                                args.Value = newUser.Patronymic;
                                Action(originalUser, args);
                                originalUser.Patronymic = newUser.Patronymic;
                                break;
                            }

                        case "birthday":
                            {
                                args.Info += " день рождения на";
                                args.Value = newUser.BirthDate.ToLongDateString();
                                Action(originalUser, args);
                                originalUser.BirthDate = newUser.BirthDate;
                                CheckUserBirthDay(originalUser);
                                break;
                            }

                        case "gender":
                            {
                                args.Info += " пол на";
                                args.Value = Mapper.GenderToString(newUser.Gender);
                                Action(originalUser, args);
                                originalUser.Gender = newUser.Gender;
                                break;
                            }

                        case "status":
                            {
                                args.Info += " статус";
                                args.Value = Mapper.StatusToString(newUser.MaritalStatus);
                                Action(originalUser, args);
                                originalUser.MaritalStatus = newUser.MaritalStatus;
                                break;
                            }

                        case "school":
                            {
                                args.Info += " школу на";
                                args.Value = newUser.School;
                                Action(originalUser, args);
                                originalUser.School = newUser.School;
                                break;
                            }

                        case "university":
                            {
                                args.Info += " университет на";
                                args.Value = newUser.University;
                                Action(originalUser, args);
                                originalUser.University = newUser.University;
                                break;
                            }

                        case "avatar":
                            {
                                args.Info += " аватар";
                                args.Value = "новый";
                                Action(originalUser, args);
                                originalUser.Avatar = newUser.Avatar;
                                break;
                            }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeUserFriend(string userLogin, string action, string friendLogin)
        {
            IUser user = GetUser(userLogin);
            IUser friend = GetUser(friendLogin);
            if (user != null && friend != null)
            {
                switch (action)
                {
                    case "add":
                        {
                            bool result = user.AddFriend(friend);
                            if (result)
                            {
                                var args = new UserEventArgs(
                                    "Добавил" + (user.Gender == Gender.Female ? "а" : string.Empty) + " в друзья",
                                    friend);
                                Action(user, args);
                                friend.GetFollower(user);
                                return true;
                            }
                            else
                            {
                                OperationCompleted(
                                    this,
                                    new ProcessEventArgs($"Пользователь {user} уже добавил в друзья {friend}!"));
                                return false;
                            }
                        }

                    case "remove":
                        {
                            bool result = user.RemoveFriend(friend);
                            if (result)
                            {
                                var args = new UserEventArgs(
                                    "Убрал" + (user.Gender == Gender.Female ? "а" : string.Empty) + " из друзей ",
                                    friend);
                                Action(user, args);
                                friend.LoseFollower(user);
                                return true;
                            }
                            else
                            {
                                OperationCompleted(
                                    this,
                                    new ProcessEventArgs(
                                        $"Пользователь {friend} уже отсутствует в списке друзей {user}!"));
                                return false;
                            }
                        }

                    default:
                        {
                            return false;
                        }
                }
            }
            else
            {
                return false;
            }
        }

        public bool CreateNews(string userLogin, string type, object value, string info)
        {
            IUser user = GetUser(userLogin);
            if (user != null)
            {
                var args = new UserEventArgs(
                    "Добавил" + (user.Gender == Gender.Female ? "а" : string.Empty),
                    string.Empty);
                switch (type)
                {
                    case "image":
                        {
                            args.Info += " изображение " + info;
                            args.Value = value;
                            user.AddNews(new Record(string.Empty, value));
                            Action(user, args);
                            return true;
                        }

                    case "message":
                        {
                            args.Info += " сообщение: " + info;
                            args.Value = value;
                            user.AddNews(new Record(string.Empty, value));
                            Action(user, args);
                            return true;
                        }

                    default:
                        {
                            OperationCompleted(
                                this,
                                new ProcessEventArgs($"Пользователю {user} не удалось добавить новость!"));
                            return false;
                        }
                }
            }
            else
            {
                return false;
            }
        }

        public IUser GetUser(string userLogin)
        {
            IUser user = _users.Find(x => x.Login == userLogin);
            if (user != null)
            {
                OperationCompleted(this, new ProcessEventArgs($"Пользователь с логином {userLogin} найден в базе"));
            }
            else
            {
                OperationCompleted(
                    this,
                    new ProcessEventArgs($"Пользователь с логином {userLogin} не был найден в базе!"));
            }

            return user;
        }

        public bool CheckSession(string userLogin, Guid token)
        {
            if (GetUser(userLogin) != null)
            {
                return _protectionModule.CheckSession(userLogin, token);
            }
            else
            {
                return false;
            }
        }

        public Guid Authentication(string userLogin, string password)
        {
            if (GetUser(userLogin) != null)
            {
                return _protectionModule.UpdateSession(userLogin, password);
            }
            else
            {
                return Guid.Empty;
            }
        }

        private void InformFollowers(object sender, UserEventArgs args)
        {
            if (sender is IUser person)
            {
                foreach (IUser follower in person.Followers)
                {
                    follower.AddNews(new Record(person.ToString(), args.Info, args.Value));
                }
            }
        }

        private void CheckBirthDays(object sender, EventArgs args)
        {
            foreach (IUser user in _users)
            {
                if (user.BirthDate.Day == DateTime.Today.Day && user.BirthDate.Month == DateTime.Today.Month)
                {
                    BirthDay(user, new UserEventArgs(null, "празднует сегодня день рождения!"));
                }
            }
        }

        private void CheckUserBirthDay(IUser user)
        {
            if (user.BirthDate.Day == DateTime.Today.Day && user.BirthDate.Month == DateTime.Today.Month)
            {
                BirthDay(user, new UserEventArgs(null, "празднует сегодня день рождения!"));
            }
        }
    }
}