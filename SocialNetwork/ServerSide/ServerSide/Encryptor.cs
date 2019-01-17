//namespace ServerSide
//{
//    using System.IO;
//    using System.Runtime.Serialization.Formatters.Binary;
//    using System.Security.Cryptography;
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;

//    public class Encryptor
//    {
//        private Dictionary<string, byte[]> _userKeys;

//        private DES _symmetric;

//        private RSACng _asymmetric;


//        public byte[] PubKeyBlob { get; }

//        public byte[] Signature { get; }

//        public string Info { get; }

//        private string _crypterPath;

//        private Log _log;

//        public Encryptor(string name, Log linkLog)
//        {
//            _symmetric = DES.Create();
//            _asymmetric = new RSACng();
//            _log = linkLog;
//            _log.MakeRecord("Система шифрования запущена");
//            Cls();
//        }

//        public byte[] GetEncryptedSymmetricKey()
//        {
//            return _asymmetric.Encrypt(_symmetric.Key, RSAEncryptionPadding.OaepSHA256);
//        }

//        public byte[] AddUserSymmetricKey()
//        {
//            return _asymmetric.Key.Export(CngKeyBlobFormat.GenericPublicBlob);
//        }

//        public byte[] DecryptWithAsymmetric(byte[] data)
//        {
//            return _asymmetric.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
//        }

//        private Dictionary<string, byte[]> OpenDictionary()
//        {
//            var dictionary = new Dictionary<string, byte[]>(0);
//            _crypterPath = "Blobs\\";
//            if (!Directory.Exists(_crypterPath))
//            {
//                Directory.CreateDirectory(_crypterPath);
//            }

//            _crypterPath += "UserInfo.blob";
//            if (File.Exists(_crypterPath))
//            {
//                BinaryFormatter serializer = new BinaryFormatter();
//                FileStream file = File.OpenRead(_crypterPath);
//                if (file.Length > 0)
//                {
//                    dictionary = (Dictionary<string, byte[]>)serializer.Deserialize(file);
//                }

//                file.Close();
//            }

//            return dictionary;
//        }

//        public void AddKey(string name, byte[] publicKey)
//        {
//            _userKeys.Add(name, publicKey);
//        }

//        public void ChangeKey(string oldName, string newName)
//        {
//            byte[] key = _userKeys[oldName];
//            _userKeys.Remove(oldName);
//            _userKeys.Add(newName, key);
//        }

//        public bool VerifySignature(string name, byte[] signature)
//        {
//            bool verifyResult = false;
//            if (_userKeys.ContainsKey(name))
//            {
//                byte[] data = Encoding.UTF8.GetBytes(name);
//                using (CngKey key = CngKey.Import(_userKeys[name], CngKeyBlobFormat.GenericPublicBlob))
//                {
//                    var signingAlg = new ECDsaCng(key);
                    
//                    verifyResult = signingAlg.VerifyData(data, signature);
//                    signingAlg.Clear();
//                }
//            }

//            return verifyResult;
//        }

//        public void Close()
//        {
//            string message = "Сохранение файла с ключами";
//            _log.MakeRecord(message);
//            BinaryFormatter serializer = new BinaryFormatter();
//            FileStream file = File.OpenWrite(_crypterPath);
//            serializer.Serialize(file, _userKeys);
//            file.Close();
//            message = $"Сохранение файла завершено\nЗавершение работы системы шифрования";
//            _log.MakeRecord(message);
//        }

        


//        public void Cls()
//        {

//            for (int i = 1; i < 16; i++)
//            {
//                string mess = "Hello world!";
//                string login = new string('a', i);
//                MemoryStream cash = new MemoryStream(Encoding.UTF8.GetBytes(login.ToCharArray()));
//                cash.Read(_symmetric.Key, 0, _symmetric.KeySize);
//                byte[] encryptedData = _asymmetric.Encrypt(cash.GetBuffer(), RSAEncryptionPadding.OaepSHA256);
//                var decryptedData = _asymmetric.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);
//                var symmetricKey = new byte[_symmetric.KeySize];
//                decryptedData.CopyTo(symmetricKey, decryptedData.Length - _symmetric.KeySize);
//                var symmetric2 = DES.Create();
//                symmetric2.Key = symmetricKey;
                
//                cash = new MemoryStream();

//                byte[] dat = Encoding.UTF8.GetBytes(login.ToCharArray());
//                cash.Read(dat, 0, dat.Length);

//                var decryptor1 = _symmetric.CreateEncryptor();

//                CryptoStream cs = new CryptoStream(cash, );

                

//                decryptedData = 

//                var encryptor1 = symmetric2.CreateDecryptor();


//                byte[] data = cryper.Key;
//                cryper.CreateDecryptor();
//            }






//            RSACng cryp = new RSACng();

            
//            string message = "hello";
//            //byte[] data = Encoding.UTF8.GetBytes(message);

//           // var encrypt = cryp.Encrypt(data, RSAEncryptionPadding.OaepSHA256);

//            var keyData = cryp.Key.Export(CngKeyBlobFormat.GenericPrivateBlob);

//            CngKey key = CngKey.Import(keyData, CngKeyBlobFormat.GenericPrivateBlob);

//            RSACng cryp2 = new RSACng(key);

//           // var decrypt = cryp2.Decrypt(encrypt, RSAEncryptionPadding.OaepSHA256);
//           // Console.WriteLine(Encoding.UTF8.GetString(decrypt));
//        }
//    }
//}