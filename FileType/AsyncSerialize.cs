using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileType
{
    internal class AsyncSerialize
    {


        static async IAsyncEnumerable<int> PrintNumbers(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return i;
            }
        }


        async public static void SerializeAsync()
        {
            Console.WriteLine("Async Serialization");
            using Stream stream = Console.OpenStandardOutput();
            var data = new { Data = PrintNumbers(3) };
            await JsonSerializer.SerializeAsync(stream, data);
            Console.WriteLine();
        }




        //There is a new API to support streaming deserialization, DeserializeAsyncEnumerable<T>(). To
        //demonstrate the use of this, add a new method that will create a new MemoryStream and then deserialize
        //from the stream:

        async  public static void DeserializeAsync()
        {
            Console.WriteLine("Async Deserialization");
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("[0,1,2,3,4]"));
            await foreach (int item in JsonSerializer.DeserializeAsyncEnumerable<int>(stream))
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
