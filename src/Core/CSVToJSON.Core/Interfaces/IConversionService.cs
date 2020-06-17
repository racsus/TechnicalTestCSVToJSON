using CSVToJSON.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToJSON.Core.Interfaces
{
    public interface IConversionService
    {
        string ConvertFile(FileConversion fileConversion);
    }
}
