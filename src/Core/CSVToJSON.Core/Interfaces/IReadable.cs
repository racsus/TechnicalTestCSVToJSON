using CSVToJSON.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToJSON.Core.Interfaces
{
    public interface IReadable
    {
        string FilePath { get; set; }
        string ConvertToJson(string data);
    }
}
