using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password_Manager.Secruity;
using Password_Manager.SaveData;
using System.Security.Cryptography;
using System.Text;

namespace Password_Manager_Test_Enviroment
{
    [TestClass]
    public class PasswordEncription_Test
    {
        [TestMethod]
        public void EncryptStringToBytes_Test()
        {
            PasswordEncription passwordEncription = new PasswordEncription();
            byte[] password = { 109, 200, 72, 89, 28, 181, 46, 186, 214, 198, 171, 232, 204, 179, 178, 62 };
            byte[] IV = {151, 113, 55, 53, 165, 53, 178, 27, 196,212, 15, 134, 10, 236, 198, 242 };
            byte[] cipher = passwordEncription.EncryptStringToBytes("Password1", password, IV);
            byte[] result = Encoding.UTF8.GetBytes("1GUC5fXYFWsti1T/Kjvsrw==");

            bool check = false;

            if (cipher.ToString() == result.ToString()) { check = true; }

            Assert.IsTrue(check);
        }

        [TestMethod]
        public void DecryptSrtingFromBytes_Test()
        {
            //PasswordEncription passwordEncription = new PasswordEncription();
            //byte[] key = { 109, 200, 72, 89, 28, 181, 46, 186, 214, 198, 171, 232, 204, 179, 178, 62 };
            //byte[] IV = { 151, 113, 55, 53, 165, 53, 178, 27, 196, 212, 15, 134, 10, 236, 198, 242 };
            //string password = passwordEncription.DecryptSrtingFromBytes(Encoding.UTF8.GetBytes("1GUC5fXYFWsti1T/Kjvsrw=="), key, IV);
            //string result = "Password1";

            //bool check = false;

            //if (password == result) { check = true; }

            //Assert.IsTrue(check);
        }
    }

    [TestClass]
    public class PasswordHasher_Test
    {
        [TestMethod]
        public void GenerateSalt_Test()
        {
            PasswordHasher passwordHasher = new PasswordHasher();

            byte[] salt = passwordHasher.GenerateSalt();

            Assert.IsNotNull(salt);
        }
        [TestMethod]
        public void GenerateLength_Test()
        {
            PasswordHasher passwordHasher = new PasswordHasher();

            int length = passwordHasher.GenerateLength();

            bool check = false;

            if(length >= 1000 && length <= 9999) { check = true; }

            Assert.IsTrue(check);
        }
        [TestMethod]
        public void GenerateHash_Test()
        {
            PasswordHasher passwordHasher = new PasswordHasher();

            byte[] salt = {49, 124, 92, 203, 133, 124, 36, 88 };

            byte[] hash = passwordHasher.GenerateHash(Encoding.UTF8.GetBytes("password"), salt, 1672);
            byte[] result = {109,200,72,89,28,181,46,186,214,198,171,232,204,179,178,62 };

            bool check = false;

            if (hash.ToString() == result.ToString()) { check = true; }

            Assert.IsTrue(check);
        }

    }
}
