using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp
{
    internal class DirectoryType
    {
        public static void FunWithDirectoryType()
        {
            // List all drives on current computer.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:");
            foreach (string s in drives)
            {
                Console.WriteLine("--> {0} ", s);
            }
            // Delete what was created.
            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                Directory.Delete("MyFolder");

                // The second parameter specifies whether you
                // wish to destroy any subdirectories.
                Directory.Delete("MyFolder2", true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
