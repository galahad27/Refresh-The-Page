using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Refresh_The_Page.Utility
{
    public class Util
    {
        private readonly static int saltLengthLimit = 32;

        public static byte[] GetSalt()
        {
            return GetSalt(saltLengthLimit);
        }

        public static byte[] GetSalt(int maxSaltLength)
        {
            byte[] salt = new byte[maxSaltLength];

            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        public static string Hash(string p, byte[] salt)
        {
            var pbkf2 = new Rfc2898DeriveBytes(p, salt, 1000);

            byte[] hash = pbkf2.GetBytes(20);
            byte[] hashBytes = new byte[20 + salt.Length];

            Array.Copy(salt, 0, hashBytes, 0, salt.Length);
            Array.Copy(hash, 0, hashBytes, salt.Length, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}