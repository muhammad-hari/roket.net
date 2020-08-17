using System;
using System.Globalization;

namespace Roket.NET
{
    public static class DateTimeConverter
    {
        /// <summary>
        /// A DateTime formater allows us to return specific DateTime format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToDateTimeFormater(this DateTimeFormat format)
        {
            return format switch
            {
                DateTimeFormat.DateFormat01 => "MM/dd/yyyy",
                DateTimeFormat.DateFormat02 => "yyyy/MM/dd",
                DateTimeFormat.DateFormat03 => "MM/dd/yyyy hh:mm:ss",
                DateTimeFormat.DateFormat04 => "yyyy-MM-dd hh:mm:ss",
                DateTimeFormat.DateFormat05 => "MM/dd/yyyyThh:mm:ss",
                DateTimeFormat.Default => "yyyy-MM-ddThh:mm:ss",
                _ => "yyyy-MM-ddThh:mm:ss",
            };
        }

        /// <summary>
        /// Convert string with specific format to DateTime.
        /// </summary>
        /// <param name="currentDateTime">The string for convert to DateTime</param>
        /// <param name="dateTime">The datetime</param>
        /// <param name="format">The format of current DateTime</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string currentDateTime, out DateTime dateTime, DateTimeFormat format = DateTimeFormat.Default)
        {
            try
            {
                return dateTime = DateTime.ParseExact(currentDateTime, format.ToDateTimeFormater(), CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new ArgumentException("An error occurred: Unable to parse the specified date");
            }
        }

        /// <summary>
        /// Check is a current date time is valid format.
        /// </summary>
        /// <param name="currentDateTime">The current datetime</param>
        /// <param name="dateTime">The out date time</param>
        /// <param name="format">The date time format</param>
        /// <returns></returns>
        public static bool IsValidDateTimeFormat(this string currentDateTime, out DateTime dateTime, DateTimeFormat format = DateTimeFormat.Default)
        {
            try
            {
                return DateTime.TryParseExact(currentDateTime, format.ToDateTimeFormater(), CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
            }
            catch (FormatException)
            {
                throw new ArgumentException("An error occurred: Unable to parse, the format is not valid");
            }
        }
    }
}
