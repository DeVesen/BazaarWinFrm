using System;
using System.IO;
using System.Security.Cryptography;


namespace DeVes.Bazaar.Data.Security
{
    /// <summary>
    /// encrypt and decrypt strings
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="key">The key.</param>
        /// <param name="iv">The IV.</param>
        /// <returns></returns>
        private static byte[] EncryptString(byte[] clearText, byte[] key, byte[] iv)
        {
            var _ms = new MemoryStream();
            var _alg = Rijndael.Create();
            _alg.Key = key;
            _alg.IV = iv;
            var _cs = new CryptoStream(_ms, _alg.CreateEncryptor(), CryptoStreamMode.Write);
            _cs.Write(clearText, 0, clearText.Length);
            _cs.Close();
            var _encryptedData = _ms.ToArray();
            return _encryptedData;
        }

        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string EncryptString(string clearText, string password)
        {
            var _clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            var _pdb = new PasswordDeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            var _encryptedData = EncryptString(_clearBytes, _pdb.GetBytes(32), _pdb.GetBytes(16));
            return Convert.ToBase64String(_encryptedData);
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="cipherData">The cipher data.</param>
        /// <param name="key">The key.</param>
        /// <param name="iv">The IV.</param>
        /// <returns></returns>
        private static byte[] DecryptString(byte[] cipherData, byte[] key, byte[] iv)
        {
            var _ms = new MemoryStream();
            var _alg = Rijndael.Create();
            _alg.Key = key;
            _alg.IV = iv;
            var _cs = new CryptoStream(_ms, _alg.CreateDecryptor(), CryptoStreamMode.Write);
            _cs.Write(cipherData, 0, cipherData.Length);
            _cs.Close();
            var _decryptedData = _ms.ToArray();
            return _decryptedData;
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string DecryptString(string cipherText, string password)
        {
            var _cipherBytes = Convert.FromBase64String(cipherText);
            var _pdb = new PasswordDeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            var _decryptedData = DecryptString(_cipherBytes, _pdb.GetBytes(32), _pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(_decryptedData);
        }
    }

}