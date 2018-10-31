using NLibrary.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace NLibrary.Tests.Security
{
    public class EncryptionTests : TestBase
    {
        const string DesSecretKey = "secret99";
        const string TripleDesSecretKey = "secret99asdfghjkqwerty12";
        const string InitVector = "!@#$%^&*";

        public EncryptionTests(ITestOutputHelper logger)
            : base(logger)
        {
        }

        [Fact]
        public void Base64Test()
        {
            string plainText = "hello world";
            string encrypted = Encryption.Base64Encrypt(plainText);
            string decrypted = Encryption.Base64Decrypt(encrypted);

            Assert.NotEqual(plainText, encrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Fact]
        public void MD5Test()
        {
            string plainText = "hello world";
            string encrypted = Encryption.MD5Hash(plainText);

            Assert.Equal("5eb63bbbe01eeed093cb22bb8f5acdc3", encrypted);
        }

        [Fact]
        public void SHA1Test()
        {
            string plainText = "hello world";
            string encrypted = Encryption.SHA1Hash(plainText);

            Assert.Equal("2AAE6C35C94FCFB415DBE95F408B9CE91EE846ED", encrypted);
        }

        [Fact]
        public void DesThrowsInvalidArgumentException()
        {
            string plainText = "hello world";

            var tupleList = new List<(string, string)>
            {
                ( "secret99", "" ),
                ( "secret99", "1234567" ),
                ( "secret99", "1234567890" ),
                ( "", "!@#$%^&*" ),
                ( "12345", "!@#$%^&*" ),
                ( "1234567890", "!@#$%^&*" )
            };

            foreach (var item in tupleList)
            {
                var exception = Record.Exception(() => Encryption.DesEncrypt(plainText, item.Item1, item.Item2));
                Assert.NotNull(exception);
                Assert.IsType<ArgumentException>(exception);
            }
        }

        [Fact]
        public void DesTest()
        {
            string plainText = "hello world";
            string encrypted = Encryption.DesEncrypt(plainText, DesSecretKey, InitVector);
            string decrypted = Encryption.DesDecrypt(encrypted, DesSecretKey, InitVector);

            Assert.NotEqual(plainText, encrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Fact]
        public void DesThrowsInvalidSecretKeyException()
        {
            string encrypted = Encryption.DesEncrypt("hello world", DesSecretKey, InitVector);

            var exception = Record.Exception(() => Encryption.DesDecrypt(encrypted, "wrongkey", InitVector));
            Assert.NotNull(exception);
            Assert.IsType<System.Security.Cryptography.CryptographicException>(exception);
        }

        [Fact]
        public void TripleDESTest()
        {
            string plainText = "hello world";
            string encrypted = Encryption.TripleDESEncrypt(plainText, TripleDesSecretKey, InitVector);
            string decrypted = Encryption.TripleDESDecrypt(encrypted, TripleDesSecretKey, InitVector);

            Assert.NotEqual(plainText, encrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Fact]
        public void TripleDESThrowsInvalidArgumentException()
        {
            string plainText = "hello world";

            var tupleList = new List<(string, string)>
            {
                ( "secret99asdfghjkqwerty12", "" ),
                ( "secret99asdfghjkqwerty12", "1234567" ),
                ( "secret99asdfghjkqwerty12", "1234567890" ),
                ( "", "!@#$%^&*" ),
                ( "12345", "!@#$%^&*" ),
                ( "1234567890", "!@#$%^&*" )
            };

            foreach (var item in tupleList)
            {
                var exception = Record.Exception(() => Encryption.TripleDESEncrypt(plainText, item.Item1, item.Item2));
                Assert.NotNull(exception);
                Assert.IsType<ArgumentException>(exception);
            }
        }

        [Fact]
        public void TripleDESThrowsWeakKeyException()
        {
            var exception = Record.Exception(() => Encryption.TripleDESEncrypt("hello world", "secret99secret99secret99", InitVector));

            Assert.NotNull(exception);
            Assert.IsType<System.Security.Cryptography.CryptographicException>(exception);
            Assert.Contains("weak key", exception.Message);
        }

        [Fact]
        public void TripleDESThrowsInvalidSecretKeyException()
        {
            string plainText = "hello world";
            string encrypted = Encryption.TripleDESEncrypt(plainText, TripleDesSecretKey, InitVector);

            var exception = Record.Exception(() => Encryption.TripleDESDecrypt(encrypted, "!@#$%^&*()1234567890abcd", InitVector));
            Assert.NotNull(exception);
            Assert.IsType<System.Security.Cryptography.CryptographicException>(exception);
        }

        [Fact]
        public void AES128BitKeyTest()
        {
            string plainText = "hello world";
            string key = "!@#$%^&*()123456";
            string encrypted = Encryption.AesEncrypt(plainText, key);
            string decrypted = Encryption.AesDecrypt(encrypted, key);

            Assert.NotEqual(plainText, encrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Fact]
        public void AES192BitKeyTest()
        {
            string plainText = "hello world";
            string key = "!@#$%^&*()1234567890qwer";
            string encrypted = Encryption.AesEncrypt(plainText, key);
            string decrypted = Encryption.AesDecrypt(encrypted, key);

            Assert.NotEqual(plainText, encrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Fact]
        public void AES256BitKeyTest()
        {
            string plainText = "hello world";
            string key = "!@#$%^&*()123456!@#$%^&*()123456";
            string encrypted = Encryption.AesEncrypt(plainText, key);
            string decrypted = Encryption.AesDecrypt(encrypted, key);

            Assert.NotEqual(plainText, encrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Fact]
        public void AESThrowsInvalidKeyException()
        {
            string plainText = "hello world";

            for (int i = 0; i < 100; i++)
            {
                string key = RandomString(i);
                var exception = Record.Exception(() => Encryption.AesEncrypt(plainText, key));
                if (i == 16 || i == 24 || i == 32)
                {
                    Assert.Null(exception);                 
                }
                else
                {
                    Assert.NotNull(exception);
                    Assert.IsType<System.Security.Cryptography.CryptographicException>(exception);
                }
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}