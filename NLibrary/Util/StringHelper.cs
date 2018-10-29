﻿using System;
using System.Globalization;
using System.Text;

namespace NLibrary.Util
{
    public class StringHelper
    {
        /// <summary>
        /// Intercept a string of the specified length
        /// </summary>
        /// <param name="value"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string SubStartString(string value, int len)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= len) return value;
            else return value.Substring(0, len);
        }

        /// <summary>
        /// Removes leading specified characters from string.(default ignore case sensitive)
        /// </summary>
        /// <param name="value">The string to trim</param>
        /// <param name="prefix">The characters to trim<</param>
        /// <returns></returns>
        public static string TrimStart(string value, string prefix)
        {
            return TrimStart(value, prefix, true);
        }

        /// <summary>
        /// Removes leading specified characters from string.
        /// </summary>
        /// <param name="value">The string to trim</param>
        /// <param name="prefix">The characters to trim</param>
        /// <param name="ignoreCase">ignore case sensitive</param>
        /// <returns></returns>
        public static string TrimStart(string value, string prefix, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            if (string.IsNullOrEmpty(prefix) || value.Length < prefix.Length) return value;

            if (ignoreCase)
            {
                if (value.Substring(0, prefix.Length).ToLower() == prefix.ToLower())
                {
                    value = value.Substring(prefix.Length);
                }
            }
            else
            {
                if (value.StartsWith(prefix)) value = value.Substring(prefix.Length);
            }
            return value;
        }

        /// <summary>
        /// Converts the specified string to title case (except for words that are entirely 
        /// in uppercase, which are considered to be acronyms).
        /// </summary>
        /// <param name="value">The string to convert to title case.</param>
        /// <returns></returns>
        public static string TitleCase(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        /// <summary>
        /// Converts the first character of string to lower case
        /// </summary>
        /// <param name="value">The string to convert</param>
        /// <returns></returns>
        public static string LowerFirst(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            return Char.ToLowerInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// Converts the first character of string to upper case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UpperFirst(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            return Char.ToUpperInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// Repeats the given string n times
        /// </summary>
        /// <param name="value">The string to repeat.</param>
        /// <param name="n">The number of times to repeat the string.</param>
        /// <returns></returns>
        public static string Repeat(string value, int n = 1)
        {
            return new StringBuilder(value.Length * n)
                .AppendJoin(value, new string[n + 1])
                .ToString();
        }

        /// <summary>
        /// Truncates string if it's longer than the given maximum string length. 
        /// The last characters of the truncated string are replaced with the omission string which defaults to "...".
        /// </summary>
        /// <param name="value">The string to truncate.</param>
        /// <param name="maxLength">The maximum string length. default 30</param>
        /// <param name="omission">The string to indicate text is omission.</param>
        /// <returns></returns>
        public static string Truncate(string value, int maxLength = 30, string omission = "...")
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + omission;
        }

        /// <summary>
        /// Splits string by separator
        /// </summary>
        /// <param name="value">The string to split</param>
        /// <param name="separator">The separator pattern to split by</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string[] Split(string value, string separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return value.Split(new string[] { separator }, options);
        }

        /// <summary>
        /// Remaps international characters to ascii compatible ones
        /// based of: https://meta.stackexchange.com/questions/7435/non-us-ascii-characters-dropped-from-full-profile-url/7696#7696
        /// </summary>
        /// <param name="c">Charcter to remap</param>
        /// <returns>Remapped character</returns>
        public static string RemapInternationalCharToAscii(char c)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }
            else if ("èéêëę".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (c == 'ř')
            {
                return "r";
            }
            else if (c == 'ł')
            {
                return "l";
            }
            else if (c == 'đ')
            {
                return "d";
            }
            else if (c == 'ß')
            {
                return "ss";
            }
            else if (c == 'þ')
            {
                return "th";
            }
            else if (c == 'ĥ')
            {
                return "h";
            }
            else if (c == 'ĵ')
            {
                return "j";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Slugifies a string
        /// </summary>
        /// <param name="text">The string to slugify</param>
        /// <param name="maxLength">Max length of slug</param>
        public static string Slugify(string text, int maxLength = 0)
        {
            // Return empty value if text is null
            if (text == null) return "";

            var normalizedString = text
                // Make lowercase
                .ToLowerInvariant()
                // Normalize the text
                .Normalize(NormalizationForm.FormD);

            var stringBuilder = new StringBuilder();
            var stringLength = normalizedString.Length;
            var prevdash = false;
            var trueLength = 0;

            char c;

            for (int i = 0; i < stringLength; i++)
            {
                c = normalizedString[i];

                switch (CharUnicodeInfo.GetUnicodeCategory(c))
                {
                    // Check if the character is a letter or a digit if the character is a
                    // international character remap it to an ascii valid character
                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        if (c < 128)
                            stringBuilder.Append(c);
                        else
                            stringBuilder.Append(RemapInternationalCharToAscii(c));

                        prevdash = false;
                        trueLength = stringBuilder.Length;
                        break;

                    // Check if the character is to be replaced by a hyphen but only if the last character wasn't
                    case UnicodeCategory.SpaceSeparator:
                    case UnicodeCategory.ConnectorPunctuation:
                    case UnicodeCategory.DashPunctuation:
                    case UnicodeCategory.OtherPunctuation:
                    case UnicodeCategory.MathSymbol:
                        if (!prevdash)
                        {
                            stringBuilder.Append('-');
                            prevdash = true;
                            trueLength = stringBuilder.Length;
                        }
                        break;
                }

                // If we are at max length, stop parsing
                if (maxLength > 0 && trueLength >= maxLength)
                    break;
            }

            // Trim excess hyphens
            var result = stringBuilder.ToString().Trim('-');

            // Remove any excess character to meet maxlength criteria
            return maxLength <= 0 || result.Length <= maxLength ? result : result.Substring(0, maxLength);
        }

        public static int GetBytesLength(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;

            return System.Text.Encoding.Default.GetBytes(value).Length;
        }

        /// <summary>
        /// Indicates whether the specified string is null or empty
        /// </summary>
        /// <param name="str">The string to test</param>
        /// <returns></returns>
        public static bool IsEmpty(string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Indicates whether the specified string is not null and empty
        /// </summary>
        /// <param name="str">The string to test</param>
        /// <returns></returns>
        public static bool IsNotEmpty(string str)
        {
            return !IsEmpty(str);
        }

        /// <summary>
        /// Converts the specified string to upper case 
        /// </summary>
        /// <param name="str">The string to convert to upper case</param>
        /// <returns></returns>
        public static string UpperCase(string str)
        {
            return str?.ToUpperInvariant();
        }

        /// <summary>
        /// Converts the specified string to lower case 
        /// </summary>
        /// <param name="str">The string to convert to lower case</param>
        /// <returns></returns>
        public static string LowerCase(string str)
        {
            return str?.ToLowerInvariant();
        }                
    }
}
