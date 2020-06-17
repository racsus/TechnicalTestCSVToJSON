using CSVToJSON.Core.Interfaces;
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Data
{
    public class DataServiceClient: IDataServiceClient
    {
        public DataServiceClient()
        {
            
        }

        public string GetData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            return File.ReadAllText(filePath);
        }
    }
}
