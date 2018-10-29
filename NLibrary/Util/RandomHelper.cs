using System;
using System.Security.Cryptography;

namespace NLibrary.Util
{
    public class RandomHelper
    {
        private const string LowerChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string UpperChars = "abcdefghijklmnopqrstuvwxyz";
        private const string NumericChars = "1234567890";
        private const string SpecialChars = "!@#$%^&*()_=+";

        public static int Next(int min, int max)
        {
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[4];

                crypto.GetBytes(buffer);
                int result = BitConverter.ToInt32(buffer, 0);

                return new Random(result).Next(min, max);
            }
        }

        public static int Next(int max)
        {
            return Next(0, max);
        }

        public static string NextString(int length, bool includeUpperChars, bool includeLowerChars, bool includeNumeric, bool includeSpecialChars, string specialChars = SpecialChars)
        {
            string chars = "";

            if (includeUpperChars)
                chars += UpperChars;

            if (includeLowerChars)
                chars += LowerChars;

            if (includeNumeric)
                chars += NumericChars;

            if (includeSpecialChars && !string.IsNullOrWhiteSpace(SpecialChars))
                chars += specialChars;

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[length];

                // If chars.Length isn't a power of 2 then there is a bias if we simply use the modulus operator. The first characters of chars will be more probable than the last ones.
                // buffer used if we encounter an unusable random byte. We will regenerate it in this buffer
                byte[] buffer = null;

                // Maximum random number that can be used without introducing a bias
                int maxRandom = byte.MaxValue - ((byte.MaxValue + 1) % chars.Length);

                crypto.GetBytes(data);

                char[] result = new char[length];

                for (int i = 0; i < length; i++)
                {
                    byte value = data[i];

                    while (value > maxRandom)
                    {
                        if (buffer == null)
                        {
                            buffer = new byte[1];
                        }

                        crypto.GetBytes(buffer);
                        value = buffer[0];
                    }

                    result[i] = chars[value % chars.Length];
                }

                return new string(result);
            }
        }

        public static string NextString(int length)
        {
            return NextString(length, true, true, true, true);
        }

        public static string NextAlphanumeric(int length)
        {
            return NextString(length, true, true, true, false);
        }

        public static string NextAlphanumericUpper(int length)
        {
            return NextString(length, true, false, true, false);
        }

        public static string NextAlphanumericLower(int length)
        {
            return NextString(length, false, true, true, false);
        }

        public static string NextNumeric(int length)
        {
            return NextString(length, false, false, true, false);
        }

        public static string NextPassword(int length)
        {
            return NextString(length, true, true, true, true);
        }

        public static string NextPassword(int length, string specialChars)
        {
            return NextString(length, true, true, true, true, specialChars);
        }        
    }
}
