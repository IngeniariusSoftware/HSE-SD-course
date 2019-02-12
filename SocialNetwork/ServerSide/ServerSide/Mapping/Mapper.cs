
namespace ServerSide.Mapping
{
    using System;

    using UserManagement;

    public static class Mapper
    {
        public static DateTime StringToDate(string data)
        {
            string[] tokens = data.Split('.');
            int day = int.Parse(tokens[0]);
            int month = int.Parse(tokens[1]);
            int year = int.Parse(tokens[2]);
            return new DateTime(year, month, day);
        }

        public static string GenderToString(Gender gender)
        {
            switch ((int)gender)
            {
                case 0:
                    {
                        return "мужской";
                    }

                case 1:
                    {
                        return "женский";
                    }

                default:
                    {
                        return "не указан";
                    }
            }
        }

        public static string StatusToString(MaritalStatus status)
        {
            switch ((int)status)
            {
                case 0:
                    {
                        return "не в браке";
                    }

                case 1:
                    {
                        return "в браке";
                    }

                default:
                    {
                        return "не указан";
                    }
            }
        }
    }
}