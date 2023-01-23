using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileType
{
   

        public class JsonStringNullToEmptyConverter : JsonConverter<string>
    {


        //n the Read method, use the Utf8JsonReader instance to read the string value for the node, and if it is 
        //null or an empty string, then return null. Otherwise, return the value read:
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value;
        }

        //In the Write method, use the Utf8JsonWriter to write an empty string if the value is null:
        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            value ??= string.Empty;
            writer.WriteStringValue(value);
        }


            // The final step is to add the custom converter into the serialization options.Create a new method named
            //HandleNullStrings() and add the following code:
             public static void HandleNullStrings()
                  {
                    Console.WriteLine("Handling Null Strings");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        PropertyNamingPolicy = null,
                        IncludeFields = true,
                        WriteIndented = true,
                        Converters = { new JsonStringNullToEmptyConverter() },
                    };
                    //Create a new object with a null string
                    var radio = new Radio
                    {
                        HasSubWoofers = true,
                        HasTweeters = true,
                        RadioId = null
                    };
                    //serialize the object to JSON
                    var json = JsonSerializer.Serialize(radio, options);
                    Console.WriteLine(json);
             }








    }
    
}
