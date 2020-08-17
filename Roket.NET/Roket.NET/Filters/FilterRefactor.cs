using System;

namespace Roket.NET
{
    public static class FilterRefactor
    {

        /// <summary>
        /// Convert string to 12 serial format.
        /// </summary>
        /// <param name="source">The source paramater to convert</param>
        /// <returns></returns>
        public static string ConvertTo12SerialFormat(this string source)
        {
            if (source.Length > 12)
                throw new ArgumentException("Failed to convert, the length of string should be 12");
            if (source.Length < 12)
                throw new ArgumentException("Failed to convert, the length of string should be 12");

            string serial = source.Substring(0, 4) + "-" +
                            source.Substring(4, 4) + "-" +
                            source.Substring(8, 4);

            return serial;

        }

        /// <summary>
        /// Convert string to 16 serial format.
        /// </summary>
        /// <param name="source">The source paramater to convert</param>
        /// <returns></returns>
        public static string ConvertTo16SerialFormat(this string source)
        {
            if (source.Length > 16)
                throw new ArgumentException("Failed to convert, the length of string should be 16");
            if (source.Length < 16)
                throw new ArgumentException("Failed to convert, the length of string should be 16");

            string serial = source.Substring(0, 4) + "-" +
                            source.Substring(4, 4) + "-" +
                            source.Substring(8, 4) + "-" +
                            source.Substring(12, 4);

            return serial;

        }
    }
}
