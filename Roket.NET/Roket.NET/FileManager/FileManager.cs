using Newtonsoft.Json;
using Roket.NET.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Roket.NET
{
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Read text from file and return string as list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="splitBy"></param>
        /// <param name="customSplit"></param>
        /// <returns></returns>
        public async Task<List<string>> ReadTextToListAsync(string filePath, string fileName, char splitBy = '\n', params char[] customSplit)
        {
            var text = default(string);
            var content = new List<string>();

            try
            {
                filePath.ToNormalizePath();

                filePath.ToResolvePath();

                await AsyncLock.LockAsync(filePath, async () =>
                {
                    await Task.Run(() =>
                    {
                        using (var streamReader = (TextReader)new StreamReader(System.IO.File.Open($"{filePath}/{fileName}", FileMode.Open, FileAccess.Read)))
                        {
                            while (streamReader.Peek() > -1)
                            {
                                text = streamReader.ReadLine();

                                if (splitBy != '\n' || splitBy != '\0')
                                    content = text.Split(new char[] { splitBy }).ToList();

                                else if (customSplit != null)
                                    content = text.Split(new char[] { Convert.ToChar(customSplit) }).ToList();

                                else
                                    content = text.Split(new char[] { '\n' }).ToList();




                            }
                        }

                    });
                });


            }
            catch (Exception)
            {
                Debug.WriteLine($"Could not found file specified");
            }



            return await Task.FromResult(content);

        }

        /// <summary>
        /// Read text from file and return as string.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> ReadTextToStringAsync(string filePath, string fileName)
        {
            var text = default(string);

            try
            {
                filePath.ToNormalizePath();

                filePath.ToResolvePath();


                await AsyncLock.LockAsync(filePath, async () =>
                {
                    await Task.Run(() =>
                    {
                        using (var streamReader = (TextReader)new StreamReader(System.IO.File.Open($"{filePath}/{fileName}", FileMode.Open, FileAccess.Read)))
                        {
                            while (streamReader.Peek() > -1)
                            {
                                text = streamReader.ReadLine();

                            }
                        }

                    });
                });


            }
            catch (Exception)
            {
                Debug.WriteLine($"Could not found file specified");
            }


            return await Task.FromResult(text);
        }

        /// <summary>
        /// Convert file text into JSON format.
        /// </summary>
        /// <param name="filePath">The full path of file's location</param>
        /// <param name="splitBy">Required for split data with specific delimiter</param>
        /// <returns></returns>
        public async Task<string> FileConvertToJsonAsync(string filePath, char splitBy = ',')
        {
            var model = await FileConvertToTempTableAsync(filePath, splitBy);

            string jsonModelOutput = JsonConvert.SerializeObject(model);

            return jsonModelOutput;

        }

        /// <summary>
        /// Convert file text into Temporary Table (Database).
        /// </summary>
        /// <param name="filePath">The full path of files location</param>
        /// <param name="splitBy">Required for split data with specific delimiter</param>
        /// <returns></returns>
        public async Task<List<DynamicMember>> FileConvertToTempTableAsync(string filePath, char splitBy = ',')
        {
            string text = "";
            List<string> listRaws = new List<string>();
            List<string> listValue = new List<string>();
            List<DynamicMember> dynamicMemberList = new List<DynamicMember>();

            int counter = 0;


            try
            {
                filePath.ToNormalizePath();

                filePath.ToResolvePath();

                await AsyncLock.LockAsync(filePath, async () =>
                {
                    await Task.Run(() =>
                    {
                        using (var streamReader = (TextReader)new StreamReader(System.IO.File.Open($"{filePath}", FileMode.Open, FileAccess.Read)))
                        {
                            text = streamReader.ReadToEnd();
                            string[] raws = text.Split(Environment.NewLine);

                            foreach (var fileItem in raws)
                            {
                                counter++;

                                listValue = fileItem.Split(new char[] { ',' }).ToList();

                                dynamicMemberList.Add(new DynamicMember()
                                {
                                    RecMode = listValue[0].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    RecType = listValue[1].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    PayorID = listValue[2].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    MemberID = listValue[3].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    MappingID = listValue[4].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    SMIID = listValue[5].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    CorporateID = listValue[6].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    NIK = listValue[7].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Division = listValue[8].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    BranchCode = listValue[9].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    BankInfo = listValue[10].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Language = listValue[11].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    TypeOfWork = listValue[12].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Race = listValue[13].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    PolicyNumber = listValue[14].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    MaritalStatus = listValue[15].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Relationship = listValue[16].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    EffectiveDate = listValue[17].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    ExpiryDate = listValue[18].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    CardNumber = listValue[19].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU1 = listValue[20].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU2 = listValue[21].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU3 = listValue[22].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU4 = listValue[23].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU5 = listValue[24].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    MemberName = listValue[25].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Address1 = listValue[26].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Address2 = listValue[27].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Address3 = listValue[28].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Address4 = listValue[29].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    City = listValue[30].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    State = listValue[31].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    PostCode = listValue[32].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    TelephoneOffice = listValue[33].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    TelephoneRes = listValue[34].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    TelephoneMobile = listValue[35].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    NRIC = listValue[36].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    PassportNo = listValue[37].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    PassportCountry = listValue[38].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU6 = listValue[39].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU7 = listValue[40].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    DateOfBirth = listValue[41].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Sex = listValue[42].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU8 = listValue[43].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    PlanID = listValue[44].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    EmploymentStatus = listValue[45].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU9 = listValue[46].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU10 = listValue[47].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU11 = listValue[48].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    DateTerminated = listValue[49].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    PreExisting = listValue[50].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU12 = listValue[51].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU13 = listValue[52].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    Remarks = listValue[53].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU14 = listValue[54].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    MemberSince = listValue[55].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU15 = listValue[58].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    PolicyInForce = listValue[57].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    MemberSuspended = listValue[58].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    RenewalActivationDate = listValue[59].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU16 = listValue[60].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU17 = listValue[61].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    IU18 = listValue[62].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"'),
                                    OptionMode = listValue[63].Replace("\"", string.Empty).TrimStart('"').TrimEnd('"')
                                });

                                listValue.Clear();
                            }
                        }

                    });
                });

                return await Task.FromResult(dynamicMemberList);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred on line:{counter} [{ex.Message}]");
                throw new Exception($"An error occurred: {ex.Message}");
            }

        }

        /// <summary>
        /// Get details info specific file.
        /// </summary>
        /// <param name="filePath">The full path of files location</param>
        /// <returns></returns>
        public string[] GetFileDetails(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {

                string[] fileDetails = new string[]
                {
                    "Name: " + fileInfo.Name,
                    "File Path: " + fileInfo.FullName,
                    "Extension: " + fileInfo.Extension,
                    "Directory Path: " + fileInfo.DirectoryName,
                    "Status Exists: " + fileInfo.Exists.ToString(),
                    "Size: " + fileInfo.Length.ToString(),
                    "Is ReadOnly: " + fileInfo.IsReadOnly.ToString(),
                    "Creation Time: " + fileInfo.CreationTime.ToString("yyyy-MM-ddThh:mm:ss"),
                    "Last Access: " + fileInfo.LastAccessTime.ToString("yyyy-MM-ddThh:mm:ss"),
                    "Last Write: " + fileInfo.LastWriteTime.ToString("yyyy-MM-ddThh:mm:ss"),
                };

                return fileDetails;
            }

            return default;

        }

        /// <summary>
        /// Get details info specific file.
        /// </summary>
        /// <param name="filePath">The full path of files location</param>
        /// <returns></returns>
        public async Task<string[]> GetFileDetailsAsync(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {

                await Task.Run(() =>
                {
                    string[] fileDetails = new string[]
                    {
                        "Name: " + fileInfo.Name,
                        "File Path: " + fileInfo.FullName,
                        "Extension: " + fileInfo.Extension,
                        "Directory Path: " + fileInfo.DirectoryName,
                        "Status Exists: " + fileInfo.Exists.ToString(),
                        "Size: " + fileInfo.Length.ToString(),
                        "Is ReadOnly: " + fileInfo.IsReadOnly.ToString(),
                        "Creation Time: " + fileInfo.CreationTime.ToString("yyyy-MM-ddThh:mm:ss"),
                        "Last Access: " + fileInfo.LastAccessTime.ToString("yyyy-MM-ddThh:mm:ss"),
                        "Last Write: " + fileInfo.LastWriteTime.ToString("yyyy-MM-ddThh:mm:ss"),
                    };

                    return fileDetails;

                });

            }

            return null;
        }
    }

}
