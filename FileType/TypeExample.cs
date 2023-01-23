using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FileType
{
    internal class TypeExample
    {




        public static void Run()
        {
                    Console.WriteLine("***** Simple I/O with the File Type *****\n");
                    string[] myTasks = {
                     "Fix bathroom sink", "Call Dave",
                     "Call Mom and Dad", "Play Xbox One"};
                    // Write out all data to file on C drive.
                    File.WriteAllLines(@"tasks.txt", myTasks);
                    // Read it all back and print out.
                    foreach (string task in File.ReadAllLines(@"tasks.txt"))
                    {
                        Console.WriteLine("TODO: {0}", task);
                    }
                    Console.ReadLine();
                    //File.Delete("tasks.txt");

                    string path = @"C:\";

                    ShowAllFiles(path);
        }


        //        The lesson here is that when you want to obtain a file handle quickly, the File type will save you some
        //keystrokes.However, one benefit of creating a FileInfo object first is that you can investigate the file using 
        //the members of the abstract FileSystemInfo base class.


        static void ShowAllFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            //string[] directories = Directory.GetDirectories(path);
            //foreach (string directory in directories)
            //{
            //    ShowAllFiles(directory);
            //}
        }

    }
}
