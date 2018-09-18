using System;
using System.Security.Cryptography;
using System.Text;
using AddressAPI3.Domain;
using Microsoft.AspNetCore.Identity;

namespace AddressAPI3.Common.Security
{
    public class PasswordHashService : IPasswordHashService
    {
        public string HashPassword(string password)
        {
            //var hasher = new PasswordHasher<User>();
            //var hashedPassword = hasher.HashPassword(new User(){}, password);

            return EncodePassword(password);
        }

        private string EncodePassword(string pass)
        {
            var passBytes = Encoding.Unicode.GetBytes(pass);

            var keyedHashAlgorithm = (KeyedHashAlgorithm)HashAlgorithm.Create("HMACSHA256");

            if (keyedHashAlgorithm == null) throw new NotSupportedException();

            var keyArray = new byte[keyedHashAlgorithm.Key.Length];

            keyedHashAlgorithm.Key = keyArray;

            var result = keyedHashAlgorithm.ComputeHash(passBytes);

            return Convert.ToBase64String(result);
        }
    }
}
