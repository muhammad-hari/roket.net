using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
            //using (MD5 md5Hash = MD5.Create())
            //{
            //    string hash = CreateCryptoMD5(md5Hash, source, salt, isUppercase);

            //    return hash;
            //}

            return "";
        }

        #endregion

        #region Base64Encoding

        /// <summary>
        /// Converts a string of bytes into a string of ASCII characters.
        /// </summary>
        /// <param name="source">The source to encode</param>
        /// <returns></returns>
        public static string Base64Encode(string source)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(source);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decode a string of ASCII character into text.
        /// </summary>
        /// <param name="source">The source to encode</param>
        /// <returns></returns>
        public static string Base64Decode(string source)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(source);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion
    }
}
