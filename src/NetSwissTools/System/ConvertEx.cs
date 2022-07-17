using System;
using System.Text;

namespace NetSwissTools.System
{
    public static class ConvertEx
    {
        public static int? ToInt32(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (int.TryParse(value.ToString(), out int val))
                return val;

            return null;
        }

        public static short? ToInt16(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (short.TryParse(value.ToString(), out short val))
                return val;

            return null;
        }

        public static long? ToInt64(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (long.TryParse(value.ToString(), out long val))
                return val;

            return null;
        }

        public static decimal? ToDecimal(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (decimal.TryParse(value.ToString(), out decimal val))
                return val;

            return null;
        }

        public static double? ToDouble(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (double.TryParse(value.ToString(), out double val))
                return val;

            return null;
        }

        public static sbyte? ToSByte(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (sbyte.TryParse(value.ToString(), out sbyte val))
                return val;

            return null;
        }

        public static DateTime? ToDateTime(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (DateTime.TryParse(value.ToString(), out DateTime val))
                return val;

            return null;
        }

        public static bool ToBoolean(this object value)
        {
            if (value == null || value == DBNull.Value)
                return false;

            if (!decimal.TryParse(value.ToString(), out decimal val))
                return false;

            return val > 0;
        }


        public static string FromBase64ToString(this string str, Encoding enc = null) =>
            (enc ?? Encoding.Default).GetString(FromBase64(str));

        public static byte[] FromBase64(this string str) =>
            Convert.FromBase64String(str);

        public static string ToBase64(this string str, Encoding enc = null) =>
            ToBase64((enc ?? Encoding.Default).GetBytes(str));

        public static string ToBase64(this byte[] data) =>
            Convert.ToBase64String(data);
    }
}
