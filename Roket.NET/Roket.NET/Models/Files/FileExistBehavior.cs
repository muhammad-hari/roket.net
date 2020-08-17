namespace Roket.NET
{
    /// <summary>
    /// behavior when new filename is exist.
    /// </summary>
    public enum FileExistBehavior
    {
        /// <summary>
        /// None: throw IOException "The destination file already exists."
        /// </summary>
        None = 0,
        /// <summary>
        /// Replace: replace the file in the destination.
        /// </summary>
        Replace = 1,
        /// <summary>
        /// Skip: skip this file.
        /// </summary>
        Skip = 2,
        /// <summary>
        /// Rename: rename the file. (like a window behavior)
        /// </summary>
        Rename = 3
    }

}
