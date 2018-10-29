using System;
using System.Text;

namespace NLibrary.Util
{
    public class SafeConvert
    {
        public static bool IsDBNull(object obj)
        {
            return Convert.IsDBNull(obj);
        }

        public static Guid ToGuid(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                try
                {
                    return new Guid(obj.ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }

            return Guid.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(object obj)
        {
            return ToTimeSpan(obj, TimeSpan.Zero);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(object obj, TimeSpan defaultValue)
        {
            if (obj != null)
                return ToTimeSpan(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(string s, TimeSpan defaultValue)
        {
            bool success = TimeSpan.TryParse(s, out TimeSpan result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(string s)
        {
            return ToTimeSpan(s, TimeSpan.Zero);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToString(string s)
        {
            return ToString(s, string.Empty);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultString"></param>
        /// <returns></returns>
        public static string ToString(string s, string defaultString)
        {
            if (s == null) return defaultString;

            return s.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultString"></param>
        /// <returns></returns>
        public static string ToString(object s, string defaultString)
        {
            if (s == null) return defaultString;

            return s.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ToDouble(string s, double defaultValue)
        {
            bool success = double.TryParse(s, out double result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ToDouble(string s)
        {
            return ToDouble(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble(object obj)
        {
            return ToDouble(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ToDouble(object obj, double defaultValue)
        {
            if (obj != null)
                return ToDouble(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float ToSingle(string s, float defaultValue)
        {
            bool success = float.TryParse(s, out float result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float ToSingle(string s)
        {
            return ToSingle(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float ToSingle(object obj)
        {
            return ToSingle(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float ToSingle(object obj, float defaultValue)
        {
            if (obj != null)
                return ToSingle(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string s, decimal defaultValue)
        {
            bool success = decimal.TryParse(s, out decimal result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string s)
        {
            return ToDecimal(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj)
        {
            return ToDecimal(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj, decimal defaultValue)
        {
            if (obj != null)
                return ToDecimal(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(string s, bool defaultValue)
        {
            if (s.TrimStart('0') == "1")
                return true;
            bool success = bool.TryParse(s, out bool result);

            return success ? result : defaultValue;
        }

        public static bool ToBoolean(string s)
        {
            return ToBoolean(s, false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBoolean(object obj)
        {
            return ToBoolean(obj, false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(object obj, bool defaultValue)
        {
            if (obj != null)
                return ToBoolean(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static char ToChar(string s, char defaultValue)
        {
            var success = char.TryParse(s, out char result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static char ToChar(string s)
        {
            return ToChar(s, '\0');
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static char ToChar(object obj)
        {
            return ToChar(obj, '\0');
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static char ToChar(object obj, char defaultValue)
        {
            if (obj != null)
                return ToChar(obj.ToString(), defaultValue);

            return defaultValue;
        }

        public static string ToHexString(byte[] bytes)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            string hexAlphabet = "0123456789ABCDEF";

            foreach (byte B in bytes)
            {
                result.Append(hexAlphabet[(int)(B >> 4)]);
                result.Append(hexAlphabet[(int)(B & 0xF)]);
            }

            return result.ToString();
        }

        public static bool TryParseHexString(byte[] bytes, out string result)
        {
            try
            {
                result = ToHexString(bytes);
                return true;
            }
            catch
            {
                result = "";
                return false;
            }
        }

        public static byte[] ToByteArray(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            int[] hexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
                0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00,0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < hex.Length; i += 2, x += 1)
            {
                bytes[x] = (byte)(hexValue[Char.ToUpper(hex[i + 0]) - '0'] << 4 |
                                  hexValue[Char.ToUpper(hex[i + 1]) - '0']);
            }

            return bytes;
        }

        public static bool TryParseByteArray(string hex, out byte[] result)
        {
            try
            {
                result = ToByteArray(hex);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static byte ToByte(string s, byte defaultValue)
        {
            var success = byte.TryParse(s, out byte result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte ToByte(string s)
        {
            return ToByte(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte ToByte(object obj)
        {
            return ToByte(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static byte ToByte(object obj, byte defaultValue)
        {
            if (obj != null)
                return ToByte(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static sbyte ToSByte(string s, sbyte defaultValue)
        {
            bool success = sbyte.TryParse(s, out sbyte result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static sbyte ToSByte(string s)
        {
            return ToSByte(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static sbyte ToSByte(object obj)
        {
            return ToSByte(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static sbyte ToSByte(object obj, sbyte defaultValue)
        {
            if (obj != null)
                return ToSByte(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short ToInt16(string s, short defaultValue)
        {
            bool success = short.TryParse(s, out short result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static short ToInt16(string s)
        {
            return ToInt16(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short ToInt16(object obj)
        {
            return ToInt16(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short ToInt16(object obj, short defaultValue)
        {
            if (obj != null)
                return ToInt16(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static ushort ToUInt16(string s, ushort defaultValue)
        {
            bool success = ushort.TryParse(s, out ushort result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ushort ToUInt16(string s)
        {
            return ToUInt16(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ushort ToUInt16(object obj)
        {
            return ToUInt16(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static ushort ToUInt16(object obj, ushort defaultValue)
        {
            if (obj != null)
                return ToUInt16(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(string s, int defaultValue)
        {
            bool success = int.TryParse(s, out int result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt32(string s)
        {
            return ToInt32(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt32(object obj)
        {
            return ToInt32(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(object obj, int defaultValue)
        {
            if (obj != null)
                return ToInt32(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static uint ToUInt32(string s, uint defaultValue)
        {
            bool success = uint.TryParse(s, out uint result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static uint ToUInt32(string s)
        {
            return ToUInt32(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static uint ToUInt32(object obj)
        {
            return ToUInt32(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static uint ToUInt32(object obj, uint defaultValue)
        {
            if (obj != null)
                return ToUInt32(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ToInt64(string s, long defaultValue)
        {
            bool success = long.TryParse(s, out long result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long ToInt64(string s)
        {
            return ToInt64(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToInt64(object obj)
        {
            return ToInt64(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ToInt64(object obj, long defaultValue)
        {
            if (obj != null)
                return ToInt64(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static ulong ToUInt64(string s, ulong defaultValue)
        {
            bool success = ulong.TryParse(s, out ulong result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ulong ToUInt64(string s)
        {
            return ToUInt64(s, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ulong ToUInt64(object obj)
        {
            return ToUInt64(obj, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static ulong ToUInt64(object obj, ulong defaultValue)
        {
            if (obj != null)
                return ToUInt64(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string s, DateTime defaultValue)
        {
            bool success = DateTime.TryParse(s, out DateTime result);

            return success ? result : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string s)
        {
            return ToDateTime(s, new DateTime(1900, 1, 1));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj)
        {
            return ToDateTime(obj, new DateTime(1900, 1, 1));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            if (obj != null)
                return ToDateTime(obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="text"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object ToEnum(Type enumType, string text, object defaultValue)
        {
            if (Enum.IsDefined(enumType, text))
            {
                return Enum.Parse(enumType, text, false);
            }

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object ToEnum(Type enumType, object obj, object defaultValue)
        {
            if (obj != null)
                return ToEnum(enumType, obj.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static object ToEnum(Type enumType, int index)
        {
            return Enum.ToObject(enumType, index);
        }
    }
}
