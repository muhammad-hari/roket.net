using System;
using System.Security.Cryptography;
using System.Text;

namespace Roket.NET
{
    public static class Cryptography
    {
        #region Salt Algorithm

        /// <summary>
        /// Get random string as a salt.
        /// </summary>
        /// <param name="size">The length size of salt</param>
        /// <returns></returns>
        public static string GetSalt(int size = 15)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new Byte[size];

            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        #endregion

        #region Encryption RDM Algorithm

        /// <summary>
        /// Get random string as a unique characters.
        /// </summary>
        /// <param name="size">The length size of string</param>
        /// <param name="uppercase">If value is true, return a string as a uppercase format</param>
        /// <returns></returns>
        public static string GetRDMString(int size = 10, bool uppercase = false)
        {
            var sb = new StringBuilder();
            var rnd = new Random();

            char seed;

            for (int index = 0; index < size; index++)
            {
                seed = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65)));
                sb.Append(seed);
            }

            if (uppercase)
                return sb.ToString().ToUpper();

            return sb.ToString().ToLower();

        }

        ///<summary>
        /// Generate a random number between two numbers.
        /// </summary>
        /// <param name="min">The minimum number</param>
        /// <param name="max">The maximum number</param>
        public static int GetRDMNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Generate a random combination special/characters string with numeric 
        /// as a standar password. 
        /// </summary>
        /// <returns></returns>
        public static string GetRDMPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(GetRDMString(4, true));
            builder.Append(GetRDMNumber(1000, 9999));
            builder.Append(GetRDMString(2, false));
            return builder.ToString();
        }

        #endregion

        #region SHA Hash Algorithm

        /// <summary>
        /// Get random secure string encryptions SHA1.
        /// </summary>
        /// <param name="size">The length size of string</param>
        /// <returns></returns>
        public static string GetCryptoSHA1(int size = 40, bool isUppercase = false)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new Byte[size];

            rng.GetBytes(buff);

            byte[] bytes = Encoding.UTF8.GetBytes(Convert.ToBase64String(buff));
            var sHA1Managed = new SHA1Managed();
            byte[] hash = sHA1Managed.ComputeHash(bytes);

            var sb = new StringBuilder();

            for (int index = 0; index < hash.Length; index++)
            {
                if (isUppercase)
                {
                    sb.Append(hash[index].ToString("X2"));
                    if (sb.Length >= size)
                        break;
                }

                sb.Append(hash[index].ToString("x2"));
                if (sb.Length >= size)
                    break;
            }

            return sb.ToString();
        }



        /// <summary>
        /// Get random secure string encryptions SHA256.
        /// </summary>
        /// <param name="size">The length size of string</param>
        /// <returns></returns>
        public static string GetCryptoSHA256(int size = 64, bool isUppercase = false)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new Byte[size];

            rng.GetBytes(buff);

            byte[] bytes = Encoding.UTF8.GetBytes(Convert.ToBase64String(buff));
            var sHA256Managed = new SHA256Managed();
            byte[] hash = sHA256Managed.ComputeHash(bytes);

            var sb = new StringBuilder();

            for (int index = 0; index < hash.Length; index++)
            {
                if (isUppercase)
                {
                    sb.Append(hash[index].ToString("X2"));
                    if (sb.Length >= size)
                        break;
                }

                sb.Append(hash[index].ToString("x2"));
                if (sb.Length >= size)
                    break;
            }

            return sb.ToString();
        }


        /// <summary>
        /// Get random secure string encryptions SHA384.
        /// </summary>
        /// <param name="size">The length size of string</param>
        /// <returns></returns>
        public static string GetCryptoSHA384(int size = 96, bool isUppercase = false)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new Byte[size];

            rng.GetBytes(buff);

            byte[] bytes = Encoding.UTF8.GetBytes(Convert.ToBase64String(buff));
            var sHA384Managed = new SHA384Managed();
            byte[] hash = sHA384Managed.ComputeHash(bytes);

            var sb = new StringBuilder();

            for (int index = 0; index < hash.Length; index++)
            {
                if (isUppercase)
                {
                    sb.Append(hash[index].ToString("X2"));
                    if (sb.Length >= size)
                        break;
                }

                sb.Append(hash[index].ToString("x2"));
                if (sb.Length >= size)
                    break;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get random secure string encryptions SHA512.
        /// </summary>
        /// <param name="size">The length size of string</param>
        /// <returns></returns>
        public static string GetCryptoSHA512(int size = 128, bool isUppercase = false)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new Byte[size];

            rng.GetBytes(buff);

            byte[] bytes = Encoding.UTF8.GetBytes(Convert.ToBase64String(buff));
            var sHA512Managed = new SHA512Managed();
            byte[] hash = sHA512Managed.ComputeHash(bytes);

            var sb = new StringBuilder();

            for (int index = 0; index < hash.Length; index++)
            {

                if (isUppercase)
                {
                    sb.Append(hash[index].ToString("X2"));
                    if (sb.Length >= size)
                        break;
                }

                sb.Append(hash[index].ToString("x2"));
                if (sb.Length >= size)
                    break;
            }

            return sb.ToString();
        }


        /// <summary>
        /// Create SHA1 Cryptography.
        /// </summary>
        /// <param name="source">The source for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public static string CreateSHA1(string source, string salt, bool isUppercase = false)
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
        /// <param name="source">The source for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public static string CreateSHA256(string source, string salt, bool isUppercase = false)
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
        /// <param name="source">The source for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public static string CreateSHA384(string source, string salt, bool isUppercase = false)
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
        /// <param name="source">The source for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public static string CreateSHA512(string source, string salt, bool isUppercase = false)
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
        /// Gets MD5 Hash Cryptography.
        /// </summary> 
        /// <param name="source">The source for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public static string GetCryptoMD5(string source, string salt = null, bool isUppercase = false)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = CreateCryptoMD5(md5Hash, source, salt, isUppercase);

                return hash;
            }
        }
        

        /// <summary>
        /// Create MD5 Cryptography.
        /// </summary> 
        /// <param name="md5Hash">A single instance parameter from <see cref="MD5"/></param>
        /// <param name="source">The source for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        public static string CreateCryptoMD5(MD5 md5Hash, string source, string salt = null, bool isUppercase = false)
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
                if(isUppercase)
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
        public static bool VerifyMD5Hash(MD5 md5Hash, string source, string salt = null, string hash = null, bool isUppercase = false)
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
    }
}
