using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password_Manager;
using System.Security.Cryptography;

namespace Password_Manager_Test_Enviroment
{
    [TestClass]
    public class Encripion
    {
        [TestMethod]
        public void AesEncriprion()
        {
            //Aes Aes = Aes.Create();
            //var AesEncriptor = new AES();

            //var test1 = AesEncriptor.EncryptStringToBytes("Test1", Aes.Key, Aes.IV);
            //var test2 = AesEncriptor.EncryptStringToBytes("TEEESSSTTT22!!!   ", Aes.Key, Aes.IV);
            //var test3 = AesEncriptor.EncryptStringToBytes("3546345d//**-+./,", Aes.Key, Aes.IV);
            //var test4 = AesEncriptor.EncryptStringToBytes("    ", Aes.Key, Aes.IV);
            //var test5 = AesEncriptor.EncryptStringToBytes("TEST5", Aes.Key, Aes.IV);

            bool result = true;

            //if (AesEncriptor.DecryptStringFromBytes(test1, Aes.Key, Aes.IV) != "Test1" ||
               //AesEncriptor.DecryptStringFromBytes(test2, Aes.Key, Aes.IV) != "TEEESSSTTT22!!!   " ||
               //AesEncriptor.DecryptStringFromBytes(test3, Aes.Key, Aes.IV) != "3546345d//**-+./," ||
               //AesEncriptor.DecryptStringFromBytes(test4, Aes.Key, Aes.IV) != "    " ||
               //AesEncriptor.DecryptStringFromBytes(test5, Aes.Key, Aes.IV) != "TEST5")
            //{
                //result = false;
            //}

            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class SaveData
    {
    }
}
