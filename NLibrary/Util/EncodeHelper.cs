using System;
using System.Text;

namespace NLibrary.Util
{
    public class EncodeHelper
    {
        /// <summary>
        /// Converts the specified string to base 64 encoding string with ASCII
        /// </summary>
        /// <param name="value">The string to convert to base 64</param>
        /// <returns></returns>
        public static string EncodeBase64(string value)
        {
            return EncodeBase64(value, Encoding.ASCII);
        }

        /// <summary>
        /// Converts the specified string to base 64 encoding string
        /// </summary>
        /// <param name="value">The string to convert to base 64</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string EncodeBase64(string value, Encoding encoding)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            byte[] toEncodeAsBytes = encoding.GetBytes(value);

            return Convert.ToBase64String(toEncodeAsBytes);
        }

        /// <summary>
        /// Converts the specified encoded string to plain text with ASCII
        /// </summary>
        /// <param name="encodedText"></param>
        /// <returns></returns>
        public static string DecodeBase64(string encodedText)
        {
            return DecodeBase64(encodedText, Encoding.ASCII);
        }

        /// <summary>
        /// Converts the specified encoded string to plain text
        /// </summary>
        /// <param name="encodedText"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DecodeBase64(string encodedText, Encoding encoding)
        {
            if (string.IsNullOrEmpty(encodedText)) return string.Empty;

            byte[] textAsBytes = Convert.FromBase64String(encodedText);
            return encoding.GetString(textAsBytes);
        }
    }
}
