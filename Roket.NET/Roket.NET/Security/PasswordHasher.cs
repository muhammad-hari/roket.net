using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Roket.NET.Security
{
    public class PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
    {
        #region SHA Hash Algorithm
       
        /// <summary>
        /// Create SHA1 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public string CreateSHA1(string source, string salt, bool isUppercase = false)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source + salt);
            var sHA1Managed = new SHA1Managed();
            byte[] hash = sHA1Managed.ComputeHash(bytes);

            var sb = new StringBuilder();

            foreach (var b in hash)
            {
                if (isUppercase)
                    sb.Append(b.ToString("X2"));

                sb.Append(b.ToString("x2"));

            }

            return sb.ToString();
        }

        /// <summary>
        /// Create SHA256 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public string CreateSHA256(string source, string salt, bool isUppercase = false)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source + salt);
            var sHA256Managed = new SHA256Managed();
            byte[] hash = sHA256Managed.ComputeHash(bytes);

            var sb = new StringBuilder();

            foreach (var b in hash)
            {
                if (isUppercase)
                    sb.Append(b.ToString("X2"));

                sb.Append(b.ToString("x2"));

            }

            return sb.ToString();
        }

        /// <summary>
        /// Create SHA384 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public string CreateSHA384(string source, string salt, bool isUppercase = false)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source + salt);
            var sHA384Managed = new SHA384Managed();
            byte[] hash = sHA384Managed.ComputeHash(bytes);

            var sb = new StringBuilder();

            foreach (var b in hash)
            {
                if (isUppercase)
                    sb.Append(b.ToString("X2"));

                sb.Append(b.ToString("x2"));

            }

            return sb.ToString();
        }

        /// <summary>
        /// Create SHA512 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public string CreateSHA512(string source, string salt, bool isUppercase = false)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source + salt);
            var sHA512Managed = new SHA512Managed();
            byte[] hash = sHA512Managed.ComputeHash(bytes);

            var sb = new StringBuilder();

            foreach (var b in hash)
            {
                if (isUppercase)
                    sb.Append(b.ToString("X2"));

                sb.Append(b.ToString("x2"));

            }

            return sb.ToString();
        }

        #endregion

        #region MD5 Hash Algorithm

        /// <summary>
        /// Create MD5 Cryptography.
        /// </summary> 
        /// <param name="md5Hash">A single instance parameter from <see cref="MD5"/></param>
        /// <param name="source">The source for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public string CreateCryptoMD5(MD5 md5Hash, string source, string salt = null, bool isUppercase = false)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source + salt));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sb = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                if (isUppercase)
                    sb.Append(data[i].ToString("X2"));

                sb.Append(data[i].ToString("x2"));

            }

            // Return the hexadecimal string.
            return sb.ToString();
        }

        /// <summary>
        /// Verify a hash against a string.
        /// </summary>
        /// <param name="md5Hash">A single instance parameter from <see cref="MD5"/></param>
        /// <param name="source">The source for hashing</param>
        /// <param name="hash">The current hash to compare with</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public bool VerifyMD5Hash(MD5 md5Hash, string source, string salt = null, string hash = null, bool isUppercase = false)
        {
            // Hash the source.
            string hashOfInput = CreateCryptoMD5(md5Hash, source, salt, isUppercase);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
                return true;
            else
                return false;
        }

        #endregion

        #region PBKDF2 Algorithm

        /// <summary>
        /// Create PBKDF2 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="iterationCount">The salt to combine with source for hashing</param>
        /// <param name="prf">Specifies the PRF which should be used for the key derivation algorithm.</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public string CreatePBKDF2(string source, int iterationCount = 10000, KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA1, bool isUppercase = false)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: source,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return isUppercase ? hashed.ToUpper() : hashed;
        }

        #endregion

        #region Verification Password

        /// <summary>
        /// If true, indicating the result of a password hash comparison is match.
        /// </summary>
        /// <param name="user">The user whose password should be verified.</param>
        /// <param name="hashedPassword">The hash value for a user's stored password.</param>
        /// <param name="providedPassword">The password supplied for comparison.</param>
        /// <returns></returns>
        public bool VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword))
                throw new ArgumentNullException(nameof(hashedPassword));
            if (string.IsNullOrEmpty(providedPassword))
                throw new ArgumentNullException(nameof(providedPassword));

            if (hashedPassword == providedPassword)
                return true;

            return false;
        }

        #endregion
    }

}
