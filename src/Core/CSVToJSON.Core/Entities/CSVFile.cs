using CSVToJSON.Core.Extensions;
using CSVToJSON.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CSVToJSON.Core.Entities
{
    public class CSVFile: IReadable
    {
        public string FilePath { get; set; }

        public CSVFile(string filePath)
        {
            FilePath = filePath;
        }

        public string ConvertToJson(string data)
        {
            var res = string.Empty;
            var lines = data.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            res = ConvertCsvFileToJsonObject(lines).RemoveUnexpectedCharacters();
            return res;
        }

        public string ConvertCsvFileToJsonObject(string[] data)
        {
            var csv = new List<string[]>();
            var combinedFieldData = string.Empty;
            var lastCombinedField = string.Empty;

            foreach (string line in data)
                csv.Add(line.Split(','));

            var properties = data[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < data.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                {
                    var propertyValue = csv[i][j].ReplaceSpecialCharacters();
                    if (properties[j].Contains("_"))
                    {
                        var propertyContent = properties[j].Split('_');
                        var propertyName = propertyContent[0].ReplaceSpecialCharacters();

                        if ((string.IsNullOrEmpty(combinedFieldData)) || (lastCombinedField == propertyName))
                        {
                            combinedFieldData += $@",""{propertyContent[1]}"": ""{propertyValue}""";
                        }
                        if (((j == properties.Length - 1) || (properties[j + 1].Split('_')[0] != propertyName)))
                        {
                            objResult.Add(propertyName, "{" + combinedFieldData.Substring(1) + "}");
                            combinedFieldData = string.Empty;
                            lastCombinedField = string.Empty;
                        } 
                        else
                        {
                            lastCombinedField = propertyName;
                        }
                    } 
                    else
                    {
                        objResult.Add(properties[j], propertyValue);
                    }
                }

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }

    }
}
