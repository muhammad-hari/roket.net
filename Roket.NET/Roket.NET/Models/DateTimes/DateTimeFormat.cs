namespace Roket.NET
{
    /// <summary>
    /// DateTime format type ISO 8601.
    /// </summary>
    public enum DateTimeFormat
    {
        /// <summary>
        /// MM/dd/yyyyTHH:mm:ss
        /// </summary>
        Default = 0,

        /// <summary>
        /// MM/dd/yyyy.
        /// </summary>
        DateFormat01 = 1,

        /// <summary>
        /// yyyy/MM/dd.
        /// </summary>
        DateFormat02 = 2,

        /// <summary>
        /// MM/dd/yyyy HH:mm:ss
        /// </summary>
        DateFormat03 = 3,

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        DateFormat04 = 4,

        /// <summary>
        /// MM/dd/yyyy hh:mm:ss
        /// </summary>
        DateFormat05 = 5,

    }
}
