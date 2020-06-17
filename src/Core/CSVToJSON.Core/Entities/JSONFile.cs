using CSVToJSON.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToJSON.Core.Entities
{
    public class JSONFile: IReadable
    {
        public string FilePath { get; set; }

        public JSONFile(string filePath)
        {
            FilePath = filePath;
        }

        public string ConvertToJson(string data)
        {
            throw new Exception("Not implemented");
        }
    }
}
