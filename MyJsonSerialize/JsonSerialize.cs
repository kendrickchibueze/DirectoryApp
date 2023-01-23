namespace MyJsonSerialize
{
    public class JsonSerialize
    {
        public static void SaveAsJsonFormat<T>(T objGraph, string fileName)
        {
            File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(objGraph));
        }
    }
}