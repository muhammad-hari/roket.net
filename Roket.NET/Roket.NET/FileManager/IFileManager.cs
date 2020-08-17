using Roket.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roket.NET
{
    public interface IFileManager
    {
        /// <summary>
        /// Read text from file and return string as list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="splitBy"></param>
        /// <param name="customSplit"></param>
        /// <returns></returns>

        Task<List<string>> ReadTextToListAsync(string filePath, string fileName, char splitBy = '\n', params char[] customSplit);

        /// <summary>
        /// Read text from file and return as string.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>

        Task<string> ReadTextToStringAsync(string filePath, string fileName);

        /// <summary>
        /// Convert file text into Temporary Table (Database).
        /// </summary>
        /// <param name="filePath">The full path of files location</param>
        /// <param name="splitBy">Required for split data with specific delimiter</param>
        /// <returns></returns>
        Task<List<DynamicMember>> FileConvertToTempTableAsync(string filePath, char splitBy = ',');

        /// <summary>
        /// Convert file text into JSON format.
        /// </summary>
        /// <param name="filePath">The full path of file's location</param>
        /// <param name="splitBy">Required for split data with specific delimiter</param>
        /// <returns></returns>
        Task<string> FileConvertToJsonAsync(string filePath, char splitBy = ',');

        /// <summary>
        /// Get details info specific file.
        /// </summary>
        /// <param name="filePath">The full path of files location</param>
        /// <returns></returns>
        Task<string[]> GetFileDetailsAsync(string filePath);

        /// <summary>
        /// Get details info specific file.
        /// </summary>
        /// <param name="filePath">The full path of files location</param>
        /// <returns></returns>
        string[] GetFileDetails(string filePath);
    }
}
