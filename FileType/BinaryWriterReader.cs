using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileType
{
    internal class BinaryWriterReader
    {


        public static void RunBinaryWriterReader()
        {
            Console.WriteLine("***** Fun with Binary Writers / Readers *****\n");
            // Open a binary writer for a file.
            FileInfo f = new FileInfo("BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                // Print out the type of BaseStream.
                // (System.IO.FileStream in this case).
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);
                // Create some data to save in the file.
                double aDouble = 1234.67;
                int anInt = 34567;
                string aString = "A, B, C";
                // Write the data.
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();


            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
            Console.ReadLine();
        }

        //Note that the constructor of BinaryWriter takes any Stream-derived type(e.g., FileStream, MemoryStream,
        //or BufferedStream). Thus, writing binary data to memory instead is as simple as supplying a valid
        //MemoryStream object.
    }
}
