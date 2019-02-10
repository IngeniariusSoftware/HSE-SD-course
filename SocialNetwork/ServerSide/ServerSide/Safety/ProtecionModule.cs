
namespace ServerSide.Safety
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class ProtectionModule
    {
        private static SHA256 encryptor = SHA256.Create();

        private List<Session> _sessions = new List<Session>();

        public static byte[] GenerateHash(string login, string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(login + password);
            return encryptor.ComputeHash(data);
        }

        public bool CheckSession(string userLogin, Guid token)
        {
            Session userSession = _sessions.Find(x => x.Login == userLogin && x.Token == token);
            if (userSession != null)
            {
                if ((DateTime.Now - userSession.LastUpdate).Minutes < 60)
                {
                    userSession.LastUpdate = DateTime.Now;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Guid UpdateSession(string userLogin, string password)
        {
            Session userSession = _sessions.Find(x => x.Login == userLogin);
            if (userSession != null)
            {
                bool isRight = true;
                byte[] key = GenerateHash(userLogin, password);
                for (int i = 0; i < key.Length && isRight; i++)
                {
                    if (key[i] != userSession.ProtectKey[i])
                    {
                        isRight = false;
                    }
                }

                if (isRight)
                {
                    userSession.LastUpdate = DateTime.Now;
                    userSession.Token = Guid.NewGuid();
                    return userSession.Token;
                }
                else
                {
                    return Guid.Empty;
                }
            }
            else
            {
                return Guid.Empty;
            }
        }

        public Guid AddSession(string userLogin, string password)
        {
            Session userSession = _sessions.Find(x => x.Login == userLogin);
            if (userSession == null)
            {
                userSession = new Session(userLogin, password);
                _sessions.Add(userSession);
            }

            return userSession.Token;
        }
    }
}