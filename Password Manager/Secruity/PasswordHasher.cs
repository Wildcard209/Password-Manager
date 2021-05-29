using System;
using System.Security.Cryptography;


namespace Password_Manager.Secruity
{
    public class PasswordHasher
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[8];
            using RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);

            return salt;
        }

        public int GenerateLength()
        {
            int length;
            Random rng = new Random();
            length = rng.Next(1000, 9999);

            return length;
        }

        public byte[] GenerateHash(byte[] password, byte[] salt, int iterations)
        {
            CheckPasswordAndSalt(password, salt);
            using var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations);
            return deriveBytes.GetBytes(16);
        }

        static private void CheckPasswordAndSalt(byte[] password, byte[] salt)
        {
            if (password == null || password.Length <= 0)
            {
                throw new ArgumentNullException("password");
            }
            if (salt == null || salt.Length <= 0)
            {
                throw new ArgumentNullException("salt");
            }
        }
    }
}
