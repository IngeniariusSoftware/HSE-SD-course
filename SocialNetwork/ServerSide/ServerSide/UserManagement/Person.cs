
namespace ServerSide.UserManagement
{
    using System;

    using ServerSide;

    public class Person : IPerson
    {
        private string _name;

        private string _surname;

        private string _patronomyc;

        private DateTime _birthDay;

        private Gender _gender;

        private MaritalStatus _maritalStatus;

        private string _university;

        private string _school;

        private int _age;

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
            Name = name;
            Surname = surname;
            Patronymcic = patronomyc;
            BirthDate = birthDate;
            Gender = gender;
            MaritalStatus = maritalStatus;
            University = university;
            School = school;
            Age = age;
        }

        public string Name
        {
            get => _name;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        "изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"изменил имя на {value}"));
                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        "изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"изменил фамилию на {value}"));
                _surname = value;
            }
        }

        public string Patronymcic
        {
            get => _patronomyc;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        $"изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"отчество на {value}"));
                _patronomyc = value;
            }
        }

        public DateTime BirthDate
        {
            get => _birthDay;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        "изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"дату рождения на {value}"));
                _birthDay = value;
            }
        }

        public Gender Gender
        {
            get => _gender;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        "изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"изменил пол на {value}"));
                _gender = value;
            }
        }

        public MaritalStatus MaritalStatus
        {
            get => _maritalStatus;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        "изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"изменил статус на {value}"));
                _maritalStatus = value;
            }
        }

        public string School
        {
            get => _school;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        "изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"изменил школу на {value}"));
                _school = value;
            }
        }

        public string University
        {
            get => _university;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        "изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"изменил университет на {value}"));
                _university = value;
            }
        }

        public int Age
        {
            get => _age;

            set
            {
                Action(
                    this,
                    new PersonEventArgs(
                        "изменил" + (_gender == Gender.Female ? "а" : string.Empty) + $"изменил возраст на {value}"));
                _age = value;
            }
        }
    }
}