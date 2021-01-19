using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Roket.NET.Security
{
    public interface IPasswordHasher<TUser>
    {

        #region SHA Hash Algorithm

        /// <summary>
        /// Create SHA1 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        string CreateSHA1(string source, string salt, bool isUppercase = false);

        /// <summary>
        /// Create SHA256 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        string CreateSHA256(string source, string salt, bool isUppercase = false);

        /// <summary>
        /// Create SHA384 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        string CreateSHA384(string source, string salt, bool isUppercase = false);

        /// <summary>
        /// Create SHA512 Cryptography.
        /// </summary>
        /// <param name="source">The source/password for hashing</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        string CreateSHA512(string source, string salt, bool isUppercase = false);

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
        string CreateCryptoMD5(MD5 md5Hash, string source, string salt = null, bool isUppercase = false);

        /// <summary>
        /// Verify a hash against a string.
        /// </summary>
        /// <param name="md5Hash">A single instance parameter from <see cref="MD5"/></param>
        /// <param name="source">The source for hashing</param>
        /// <param name="hash">The current hash to compare with</param>
        /// <param name="salt">The salt to combine with source for hashing</param>
        /// <param name="isUppercase">If value is true, return as a uppercase format</param>
        /// <returns></returns>
        bool VerifyMD5Hash(MD5 md5Hash, string source, string salt = null, string hash = null, bool isUppercase = false);

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
        string CreatePBKDF2(string source, int iterationCount = 10000, KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA1, bool isUppercase = false);

        #endregion
    }
}
