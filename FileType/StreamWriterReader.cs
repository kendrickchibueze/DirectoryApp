using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileType
{
    internal class StreamWriterReader
    {

        public static void WriteRead()
        {
            Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");
            // Get a StreamWriter and write string data.
            using (StreamWriter writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don't forget Father's Day this year...");
                writer.WriteLine("Don't forget these numbers:");
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + " ");
                }
                // Insert a new line.
                writer.Write(writer.NewLine);
            }
            Console.WriteLine("Created file and wrote some thoughts...");
            Console.ReadLine();
            //File.Delete("reminders.txt");

            //string currentDirectory = Directory.GetCurrentDirectory();

            //Console.WriteLine("The current directory is: " + currentDirectory);


            string path = Path.Combine(Directory.GetCurrentDirectory(), "reminders.txt");
            if (File.Exists(path))
            {
                Console.WriteLine("File found at: " + path);
            }
            else
            {
                Console.WriteLine("File not found.");
            }



            // Now read data from file.
            Console.WriteLine("Here are your thoughts:\n");
            using (StreamReader sr = File.OpenText("reminders.txt"))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
            Console.ReadLine();
        }
    }
}
