using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordHasherLibrary
{
    public class PasswordHasher
    {
        public string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public byte[] GetPasswordHash(string password, string salt)
        {
            string saltedPassword = password + salt;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return sha256Hash.ComputeHash(sourceBytes);
            }
        }
    }
}