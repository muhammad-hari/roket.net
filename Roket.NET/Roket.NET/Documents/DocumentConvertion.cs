using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Roket.NET.Documents
{
    public class DocumentConvertion : IDocumentCovertion<DataTable> 
    {
        public DataTable DataTable { get; set; }

        public DocumentConvertion()
        {
            DataTable = new DataTable();
        }

        public async Task<List<TModel>> ConvertCsvToJsonAsync<TModel>(string sourceFile, TModel models)
        {
            try
            {
                sourceFile.ToNormalizePath();
                sourceFile.ToResolvePath();
                FileStream stream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);

                using (var reader = (TextReader)new StreamReader(stream))
                {
                    int position = 0;
                    int index = 0;
                    string lines = string.Empty;

                    foreach (var col in reader.ReadLine().Split(new char[] { ',' }))
                    {
                        DataTable.Columns.Add(col.Contains("\"") ?
                            col.Replace("\"", "") : col, typeof(string));
                        position += col.Length;
                    }

                    stream.Seek(position, SeekOrigin.Current);

                    while ((lines = reader.ReadLine()) != null)
                    {

                        var content = Regex.Split(lines, ",");

                        DataRow dataRow = DataTable.NewRow();

                        for (index = 0; index < content.Length; index++)
                        {
                            dataRow[index] = content[index].Contains("\"") ? content[index].Replace("\"", "") :
                                content[index];
                        }

                        DataTable.Rows.Add(dataRow);
                    }

                    var json = JsonConvert.SerializeObject(DataTable, Formatting.Indented);

                    var model = JsonConvert.DeserializeObject<List<TModel>>(json);

                    return await Task.FromResult(model);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public class Grid
        {
            public int No { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
