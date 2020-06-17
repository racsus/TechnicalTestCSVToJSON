using CSVToJSON.Core.DTO;
using CSVToJSON.Core.Entities;
using CSVToJSON.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CSVToJSON.Core.Services
{
    public class ConversionService: IConversionService
    {
        private static IDataServiceClient _dataServiceClient;

        public ConversionService(IDataServiceClient dataServiceClient)
        {
            _dataServiceClient = dataServiceClient;
        }

        /// <summary>
        /// Convert the specified file into the specified format
        /// </summary>
        /// <param name="fileConversion">Object which contains the origin file and the conversion type</param>
        /// <returns></returns>
        public string ConvertFile(FileConversion fileConversion)
        {
            string res = string.Empty;
            var fileData = _dataServiceClient.GetData(fileConversion.Origin.FilePath);
            string json = fileConversion.Origin.ConvertToJson(fileData);

            switch (fileConversion.DestinationType)
            {
                case Enums.TypeEnum.JSON:
                    res = json;
                    break;
                case Enums.TypeEnum.XML:
                    res = ConverToXML(json);
                    break;
                default:
                    break;
            }
            return res;
        }

        private string ConverToXML(string json)
        {
            var res = string.Empty;
            XmlDocument xdoc = JsonConvert.DeserializeXmlNode("{\"root\":" + json  + "}", "root");
            res = xdoc.OuterXml;
            return res;
        }
    }
}
