using CSVToJSON.Core.Enums;
using CSVToJSON.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToJSON.Core.DTO
{
    public class FileConversion
    {
        public IReadable Origin { get; set; }
        public TypeEnum DestinationType { get; set; }
    }
}
