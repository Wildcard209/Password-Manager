using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Password_Manager.Encription
{
    public class MainEncription
    {
        public byte[] EncryptStringToBytes(string Password, byte[] Key, byte[] IV)
        {
            CheckInput(Password);
            CheckKeyAndIV(Key, IV);

            byte[] Chiper;

            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(Password);
            }
            Chiper = msEncrypt.ToArray();

            return Chiper;
        }

        public string DecryptSrtingFromBytes(byte[] Cipher, byte[] Key, byte[] IV)
        {
            CheckInput(Cipher);
            CheckKeyAndIV(Key, IV);

            string Password = null;

            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Cipher))
            {
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new StreamReader(csDecrypt);
                Password = srDecrypt.ReadToEnd();
            }

            return Password;
        }

        static private void CheckKeyAndIV(byte[] Key, byte[] IV)
        {
            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("IV");
            }
        }

        static private void CheckInput(string Password)
        {
            if (Password == null || Password.Length <= 0)
            {
                throw new ArgumentNullException("Password");
            }
        }

        static private void CheckInput(byte[] Cipher)
        {
            if (Cipher == null || Cipher.Length <= 0)
            {
                throw new ArgumentNullException("Cipher");
            }
        }
    }
}
