
namespace ServerSide.Safety
{
    using System;

    public class Session
    {
        public Session(string login, string password)
        {
            Login = login;
            ProtectKey = ProtectionModule.GenerateHash(login, password);
            Token = Guid.NewGuid();
            LastUpdate = DateTime.Now;
        }

        public string Login { get; }

        public byte[] ProtectKey { get; }

        public Guid Token { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}