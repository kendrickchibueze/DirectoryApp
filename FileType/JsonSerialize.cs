using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileType
{
    internal class JsonSerialize
    {

        public static void SaveAsJsonFormat<T>(T objGraph, string fileName)
        {
            File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(objGraph));
        }
    }
}
