using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToJSON.Core.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveUnexpectedCharacters(this string source)
        {
            return source.Replace(@"\", "").Replace(@"""{""", @"{""").Replace(@"""}""", @"""}");
        }

        public static string ReplaceSpecialCharacters(this string source)
        {
            return source.Replace(@"""", "'");
        }
    }
}
