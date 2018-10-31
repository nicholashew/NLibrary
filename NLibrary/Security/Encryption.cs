using System;
using System.Security.Cryptography;
using System.Text;

namespace NLibrary.Security
{
    /// <summary>
    /// Simple Encryption
    /// </summary>
    public class Encryption
    {
        #region Base64

        // <summary>
        /// Base64 Encrypts a string value generating a base64-encoded string.
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted</param>
        /// <returns></returns>
        public static string Base64Encrypt(string plainText)
        {
            string result = string.Empty;

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                result = Convert.ToBase64String(bytes);
            }
            catch
            {
                result = plainText;
            }
            return result;
        }

        /// <summary>
        /// Base64 Decrypts a base64-encoded cipher text value generating a string result.
        /// </summary>
        /// <param name="cipherText">Base64-encoded cipher text string to be decrypted.</param>
        /// <returns></returns>
        public static string Base64Decrypt(string cipherText)
        {
            string result = string.Empty;
            try
            {
                byte[] bytes = Convert.FromBase64String(cipherText);
                result = Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                //base 64 chars is null
                result = cipherText;
            }

            return result;
        }

        #endregion Base64

        #region MD5

        /// <summary>
        /// MD5 Encryption
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted</param>
        /// <returns></returns>
        public static string MD5Hash(string plainText)
        {
            return MD5Hash(plainText, Encoding.UTF8);
        }

        /// <summary>
        /// MD5 Encryption
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted</param>
        /// <param name="encode">encoding to be use</param>
        /// <returns></returns>
        public static string MD5Hash(string plainText, Encoding encode)
        {
            var hash = new StringBuilder();
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(encode.GetBytes(plainText));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                hash.Append(result[i].ToString("x2"));
            }

            return hash.ToString();
        }

        #endregion MD5

        #region SHA1

        /// <summary>
        /// SHA1 Encrypts a string value generating a byte data in hyphenated hexadecimal (base-16) encoded uppercase string.
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted</param>
        /// <returns>Cipher text with SHA-1 (Secure Hash Algorithm 1)</returns>
        public static string SHA1Hash(string plainText)
        {
            var sha1 = SHA1.Create();
            string encoded = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(plainText))).Replace("-", "");
            return encoded;
        }

        #endregion SHA1

        #region DES

        /// <summary>
        /// DES Encrypts a string value generating a base64-encoded string.
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted</param>
        /// <param name="secretKey">Secret Key (must be 8 characters long)</param>
        /// <param name="initVector">Initialization Vector (must be 8 characters long)</param>
        /// <returns>Cipher text formatted as a base64-encoded string</returns>
        public static string DesEncrypt(string plainText, string secretKey, string initVector)
        {
            if (secretKey.Length != 8)
                throw new ArgumentException("secretKey should be 8 characters");

            if (initVector.Length != 8)
                throw new ArgumentException("initVector should be 8 characters");

            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] result;
            var DES = new DESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(secretKey),
                IV = Encoding.UTF8.GetBytes(initVector)
            };
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            result = desencrypt.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// DES Decrypts a base64-encoded cipher text value generating a string result.
        /// </summary>
        /// <param name="cipherText">Base64-encoded cipher text string to be decrypted.</param>
        /// <param name="secretKey">Secret Key (must be 8 characters long)</param>
        /// <param name="initVector">Initialization Vector (must be 8 characters long)</param>
        /// <returns>Decrypted string value.</returns>
        public static string DesDecrypt(string cipherText, string secretKey, string initVector)
        {
            if (secretKey.Length != 8)
                throw new ArgumentException("secretKey should be 8 characters");

            if (initVector.Length != 8)
                throw new ArgumentException("initVector should be 8 characters");

            byte[] data = Convert.FromBase64String(cipherText);
            var DES = new DESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(secretKey),
                IV = Encoding.UTF8.GetBytes(initVector)
            };
            ICryptoTransform desencrypt = DES.CreateDecryptor();
            byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);     
            return Encoding.UTF8.GetString(result);
        }

        #endregion

        #region 3Des/Triple-DES (Triple Data Encryption Standard)

        /// <summary>
        /// 3Des Encryption
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted (Internal encoded using UTF8)</param>
        /// <param name="secretKey">Secret Key (must be 24 characters long)</param>
        /// <param name="initVector">Initialization Vector (must be 8 characters long)</param>
        /// <returns>base64 encoded string</returns>
        public static string TripleDESEncrypt(string plainText, string secretKey, string initVector)
        {
            if (secretKey.Length != 24)
                throw new ArgumentException("secretKey should be 24 characters");

            if (initVector.Length != 8)
                throw new ArgumentException("initVector should be 8 characters");

            var tdsp = new TripleDESCryptoServiceProvider
            {

                //Set Initialization Vector
                IV = Encoding.UTF8.GetBytes(initVector),
                //Set Secret Key 
                Key = System.Text.Encoding.UTF8.GetBytes(secretKey),
                //Set the encryption algorithm for the calculation mode ECB (java compatible)
                Mode = CipherMode.CBC,
                //Set the encryption algorithm for the padding mode PKCS7 (java compatible)
                Padding = PaddingMode.PKCS7
            };

            //obtain encoded string in utf-8 byte            
            byte[] data = Encoding.UTF8.GetBytes(plainText);

            //convert into base64 after encrypted
            ICryptoTransform ct = tdsp.CreateEncryptor();
            string result = Convert.ToBase64String(ct.TransformFinalBlock(data, 0, data.Length));
            return result;
        }

        /// <summary>
        /// 3Des Decryption
        /// </summary>
        /// <param name="cipherText">Base64-encoded cipher text string to be decrypted.</param>
        /// <param name="secretKey">Secret Key (must be 24 characters long)</param>
        /// <param name="initVector">Initialization Vector (must be 8 characters long)</param>
        /// <returns>decrypted string (Internal decoded using UTF8 for decryption)</returns>        
        public static string TripleDESDecrypt(string cipherText, string secretKey, string initVector)
        {
            if (secretKey.Length != 24)
                throw new ArgumentException("secretKey should be 24 characters");

            if (initVector.Length != 8)
                throw new ArgumentException("initVector should be 8 characters");

            var tdsp = new TripleDESCryptoServiceProvider
            {
                //tdsp.IV = Encoding.UTF8.GetBytes(IV);
                //Set Initialization Vector
                IV = Encoding.UTF8.GetBytes(initVector),
                //Set Secret Key 
                Key = Encoding.UTF8.GetBytes(secretKey),
                //Set the encryption algorithm for the calculation mode ECB (java compatible)
                Mode = CipherMode.CBC,
                //Set the encryption algorithm for the padding mode PKCS7 (java compatible)
                Padding = PaddingMode.PKCS7
            };

            //The encrypted string with base64 encoding, we need to resolve to bytes base64
            byte[] data = Convert.FromBase64String(cipherText);

            //Decrypt the original string utf8 encoding
            ICryptoTransform ct = tdsp.CreateDecryptor();
            string result = Encoding.UTF8.GetString(ct.TransformFinalBlock(data, 0, data.Length));
            return result;
        }
        #endregion 3Des/Triple-DES (Triple Data Encryption Standard)

        #region AES

        /// <summary>
        ///  AES Encryption
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AesEncrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            var rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        ///  AES Decryption
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AesDecrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            byte[] toEncryptArray = Convert.FromBase64String(str);

            var rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }

        #endregion AES
    }
}
