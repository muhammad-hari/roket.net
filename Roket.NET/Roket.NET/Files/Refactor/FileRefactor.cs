using System.IO;
using System.Runtime.InteropServices;

namespace Roket.NET
{
    public static class FileRefactor
    {
        /// <summary>
        /// Normalizing a path based on the current operating systems like Windows,
        /// Linux, Mac OS.
        /// </summary>
        /// <param name="filePath">The path of file to normalize</param>
        /// <returns></returns>
        public static string ToNormalizePath(this string filePath)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return filePath?.Replace('/', '\\').Trim();
            else
                return filePath?.Replace('\\', '/').Trim();

        }


        /// <summary>
        /// Resolve any relative element of the path to absolute path.
        /// </summary>
        /// <param name="filePath">The path of file</param>
        /// <returns></returns>
        public static string ToResolvePath(this string filePath) => Path.GetFullPath(filePath);

        /// <summary>
        /// Check specific file extension.
        /// </summary>
        /// <param name="filePath">The path of file to validation</param>
        /// <returns></returns>
        public static string GetFileExtension(this string filePath) => Path.GetExtension(filePath);

        public static bool IsValidExtension(this string filePath, string fileFilter = ".txt")
        {
            var extension = filePath.GetFileExtension().ToLower();

            if (extension == fileFilter)
                return true;
            else
                return false;
        }


        // -------------------------------------------------------------------------------------
        // string targetFile = System.IO.Path.Combine(@"D://test", "New Text Document.txt");
        // string newFileName = "Foo.txt";
        //
        // full pattern
        //    System.IO.FileInfo fileInfo = new System.IO.FileInfo(targetFile);
        //    fileInfo.Rename(newFileName);
        //
        // or short form
        //    new System.IO.FileInfo(targetFile).Rename(newFileName);
        // --------------------------------------------------------------------------------------
        /// <summary>
        /// Rename the file.
        /// </summary>
        /// <param name="fileInfo">the target file.</param>
        /// <param name="newFileName">new filename with extension.</param>
        /// <param name="fileExistBehavior">behavior when new filename is exist.</param>
        public static void RenameFile(this System.IO.FileInfo fileInfo, string newFileName, FileExistBehavior fileExistBehavior = FileExistBehavior.None)
        {
            string newFileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(newFileName);
            string newFileNameExtension = System.IO.Path.GetExtension(newFileName);
            string newFilePath = System.IO.Path.Combine(fileInfo.Directory.FullName, newFileName);

            if (System.IO.File.Exists(newFilePath))
            {
                switch (fileExistBehavior)
                {
                    case FileExistBehavior.None:
                        throw new System.IO.IOException("The destination file already exists.");
                    case FileExistBehavior.Replace:
                        System.IO.File.Delete(newFilePath);
                        break;
                    case FileExistBehavior.Rename:
                        int dupplicate_count = 0;
                        string newFileNameWithDupplicateIndex;
                        string newFilePathWithDupplicateIndex;
                        do
                        {
                            dupplicate_count++;
                            newFileNameWithDupplicateIndex = newFileNameWithoutExtension + " (" + dupplicate_count + ")" + newFileNameExtension;
                            newFilePathWithDupplicateIndex = System.IO.Path.Combine(fileInfo.Directory.FullName, newFileNameWithDupplicateIndex);
                        } while (System.IO.File.Exists(newFilePathWithDupplicateIndex));
                        newFilePath = newFilePathWithDupplicateIndex;
                        break;
                    case FileExistBehavior.Skip:
                        return;
                }
            }
            System.IO.File.Move(fileInfo.FullName, newFilePath);
        }
    }
}
