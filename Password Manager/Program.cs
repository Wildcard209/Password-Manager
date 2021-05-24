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
            string name;
            string passwordInput;
            byte[] passwordKey;
            byte[] passwordEncyptied;

            Console.Write("Please input name of application of the password: ");
            name = Console.ReadLine();
            Console.Write("Please input password to be enyptid: ");
            passwordInput = Console.ReadLine();
            Console.Write("Please input password to be used as the key: ");
            passwordKey = Encoding.Unicode.GetBytes(Console.ReadLine());

            Password_Manager.Encription.MainEncription encription = new Password_Manager.Encription.MainEncription();
            Aes ase = Aes.Create();

            byte[] salt1 = new byte[8];

            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(salt1);
            }

            Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(passwordKey, salt1,1000);

            passwordEncyptied = encription.EncryptStringToBytes(passwordInput, k1.GetBytes(16), ase.IV);

            Password_Manager.SaveData.PasswordData passwordData = new Password_Manager.SaveData.PasswordData();
            Password_Manager.SaveData.MainSaver saver = new Password_Manager.SaveData.MainSaver();

            passwordData.PasswordDataList = saver.Loader();
            passwordData.AddPassword(name, passwordEncyptied, ase.IV);

            saver.Saver(passwordData);
        }
    }
}