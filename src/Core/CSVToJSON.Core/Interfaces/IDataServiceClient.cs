using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToJSON.Core.Interfaces
{
    public interface IDataServiceClient
    {
        string GetData(string filePath);
    }
}
