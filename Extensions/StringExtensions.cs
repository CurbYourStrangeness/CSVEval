using System;

namespace CSVEval.Extensions
{
    public static class StringExtensions
    {
        public static String ReadArrayField(this string[] fieldData, int index, string defaultValue = "")
        {
            if (fieldData != null && index >= 0 && index < fieldData.Length)
            {
                return !string.IsNullOrEmpty(fieldData[index]) ? fieldData[index].Trim() : defaultValue;
            }

            return defaultValue;
        }

        public static DateTime ToDateTime(this string stringDate, string format = "MMddyyyy")
        {
            DateTime date = DateTime.MinValue;
            DateTime.TryParseExact(stringDate, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);

            return date;
        }
    }
}
