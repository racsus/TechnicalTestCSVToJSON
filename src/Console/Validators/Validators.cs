using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVToJSON.Validators
{
    public static class Validators
    {
        public static string Check(string[] args)
        {
            var res = string.Empty;

            if (args.Length != 2)
            {
                return "Incorrect parameters. Parameter1 = Source CSV file, Parameter2 = Conversion type (json or xml).";
            }

            if (!System.IO.File.Exists(args[0]))
            {
                return "The CSV file doesn't exist.";
            }

            if (!Path.GetExtension(args[0]).Contains("csv", StringComparison.OrdinalIgnoreCase))
            {
                return "The file extension has to be .csv";
            }

            if ((!args[1].Contains("json", StringComparison.OrdinalIgnoreCase)) && (!args[1].Contains("xml", StringComparison.OrdinalIgnoreCase)))
            {
                return "Destination type has to be xml or json";
            }

            return res;
        }
    }
}
