using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main()
        {
            Password_Manager.Encription.MainEncription AES = new Password_Manager.Encription.MainEncription();
            Password_Manager.SaveData.PasswordData passwordData = new Password_Manager.SaveData.PasswordData();
            Password_Manager.SaveData.MainSaver mainSaver = new Password_Manager.SaveData.MainSaver();

            passwordData.PasswordDataList = mainSaver.Loader();

            string test1 = "Test encryption";
            string test2 = "Ahhhhhhhh";
            string test3 = "Pasword be goldone11234234!";

            using Aes myAes = Aes.Create();

            // Encrypt the string to an array of bytes.
            byte[] encrypted1 = AES.EncryptStringToBytes(test1, myAes.Key, myAes.IV);
            byte[] encrypted2 = AES.EncryptStringToBytes(test2, myAes.Key, myAes.IV);
            byte[] encrypted3 = AES.EncryptStringToBytes(test3, myAes.Key, myAes.IV);

            passwordData.AddPassword(test1, encrypted1, myAes.IV);
            passwordData.AddPassword(test2, encrypted2, myAes.IV);
            passwordData.AddPassword(test3, encrypted3, myAes.IV);

            mainSaver.Saver(passwordData);

        }
    }
}