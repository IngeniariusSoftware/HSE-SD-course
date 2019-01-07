using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography;

    public class Crypter
    {
        private Dictionary<string, byte[]> userKeys;

        private CngKey keySignature { get; }

        public byte[] pubKeyBlob { get; }

        public byte[] signature { get; }

        public string info { get; }

        private string crypterPath;

        private Log log;

        public Crypter(string name, Log linkLog)
        {
            keySignature = CngKey.Create(CngAlgorithm.ECDsaP256);
            pubKeyBlob = keySignature.Export(CngKeyBlobFormat.GenericPublicBlob);
            info = name;
            signature = CreateSignature();
            userKeys = OpenDictionary();
            log = linkLog;
            string message = "Система шифрования запущена";
            log.MakeLog(message);
        }

        private Dictionary<string, byte[]> OpenDictionary()
        {
            var dictionary = new Dictionary<string, byte[]>(0);
            crypterPath = "Blobs\\";
            if (!Directory.Exists(crypterPath))
            {
                Directory.CreateDirectory(crypterPath);
            }

            crypterPath += "UserInfo.blob";
            if (File.Exists(crypterPath))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                FileStream file = File.OpenRead(crypterPath);
                if (file.Length > 0)
                {
                    dictionary = (Dictionary<string, byte[]>)serializer.Deserialize(file);
                }

                file.Close();
            }

            return dictionary;
        }

        public void AddKey(string name, byte[] publicKey)
        {
            userKeys.Add(name, publicKey);
        }

        public void ChangeKey(string oldName, string newName)
        {
            byte[] key = userKeys[oldName];
            userKeys.Remove(oldName);
            userKeys.Add(newName, key);
        }

        private byte[] CreateSignature()
        {
            byte[] data = Encoding.UTF8.GetBytes(info);
            var signingAlg = new ECDsaCng(keySignature);
            var signatureBuffer = signingAlg.SignData(data);
            signingAlg.Clear();
            return signatureBuffer;
        }

        public bool VerifySignature(string name, byte[] signature)
        {
            bool verifyResult = false;
            if (userKeys.ContainsKey(name))
            {
                byte[] data = Encoding.UTF8.GetBytes(name);
                using (CngKey key = CngKey.Import(userKeys[name], CngKeyBlobFormat.GenericPublicBlob))
                {
                    var signingAlg = new ECDsaCng(key);
                    verifyResult = signingAlg.VerifyData(data, signature);
                    signingAlg.Clear();
                }
            }

            return verifyResult;
        }

        public void Close()
        {
            string message = "Сохранение файла с ключами";
            log.MakeLog(message);
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream file = File.OpenWrite(crypterPath);
            serializer.Serialize(file, userKeys);
            file.Close();
            message = $"Сохранение файла завершено\nЗавершение работы системы шифрования";
            log.MakeLog(message);
        }
    }
}