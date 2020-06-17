using CSVToJSON.Core.DTO;
using CSVToJSON.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToJSON.Factories
{
    public static class FileConversionFactory
    {
        public static FileConversion BuildFileConversion(string originFile, string destinationType)
        {
            var res = new FileConversion();
            res.Origin = new CSVFile(originFile);

            switch (destinationType.ToLower())
            {
                case "xml":
                    res.DestinationType = Core.Enums.TypeEnum.XML;
                    break;
                case "json":
                    res.DestinationType = Core.Enums.TypeEnum.JSON;
                    break;
                case "csv":
                    res.DestinationType = Core.Enums.TypeEnum.CSV;
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}
