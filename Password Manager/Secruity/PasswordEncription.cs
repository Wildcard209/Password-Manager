using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Password_Manager.Secruity
{
    public class PasswordEncription
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

        public string DecryptSrtingFromBytes(byte[] cipher, byte[] key, byte[] IV)
        {
            CheckInput(cipher);
            CheckKeyAndIV(key, IV);

            string Password = null;

            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = IV;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipher))
            {
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new StreamReader(csDecrypt);
                Password = srDecrypt.ReadToEnd();
            }

            return Password;
        }

        static private void CheckKeyAndIV(byte[] key, byte[] IV)
        {
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("IV");
            }
        }

        static private void CheckInput(string password)
        {
            if (password == null || password.Length <= 0)
            {
                throw new ArgumentNullException("password");
            }
        }

        static private void CheckInput(byte[] cipher)
        {
            if (cipher == null || cipher.Length <= 0)
            {
                throw new ArgumentNullException("cipher");
            }
        }


    }
}
