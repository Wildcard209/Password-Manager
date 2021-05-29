using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.SaveData;
using Password_Manager.Secruity;

namespace Project
{
    class Program
    {
        static void Main()
        {
            MainSaver mainSaver = new MainSaver();
            HasherData hasherData = new HasherData();
            PasswordData passwordData = new PasswordData();

            PasswordEncription passwordEncription = new PasswordEncription();
            PasswordHasher passwordHasher = new PasswordHasher();

            passwordData.PasswordDataList = mainSaver.Loader();
            hasherData.HasherDataList = mainSaver.Loader("HasherData.json");

            byte[] hash = passwordHasher.GenerateHash(Encoding.UTF8.GetBytes("password"), hasherData.HasherDataList[0].Salt, hasherData.HasherDataList[0].Iterations);

            string test1 = passwordEncription.DecryptSrtingFromBytes(passwordData.PasswordDataList[0].Cipher, passwordHasher.GenerateHash(Encoding.UTF8.GetBytes("password"), hasherData.HasherDataList[0].Salt, hasherData.HasherDataList[0].Iterations), passwordData.PasswordDataList[0].IV);
            string test2 = passwordEncription.DecryptSrtingFromBytes(passwordData.PasswordDataList[1].Cipher, passwordHasher.GenerateHash(Encoding.UTF8.GetBytes("password"), hasherData.HasherDataList[1].Salt, hasherData.HasherDataList[1].Iterations), passwordData.PasswordDataList[1].IV);
            string test3 = passwordEncription.DecryptSrtingFromBytes(passwordData.PasswordDataList[2].Cipher, passwordHasher.GenerateHash(Encoding.UTF8.GetBytes("password"), hasherData.HasherDataList[2].Salt, hasherData.HasherDataList[2].Iterations), passwordData.PasswordDataList[2].IV);

            Console.WriteLine("Test 1 {0}", test1);
            Console.WriteLine("Test 2 {0}", test2);
            Console.WriteLine("Test 3 {0}", test3);
        }
    }
}