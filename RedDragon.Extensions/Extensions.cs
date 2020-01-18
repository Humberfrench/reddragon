using System;

namespace RedDragon.Extensions
{
    public static class Extensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
        public static int Int(this Enum enumer)
        {
            return Convert.ToInt32(enumer);
        }
        public static string TratarStringNull(this string value)
        {
            if (value.IsNullOrEmptyOrWhiteSpace())
            {
                return "";
            }

            return value;
        }
    }
}
