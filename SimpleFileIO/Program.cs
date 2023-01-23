using System.ComponentModel;

namespace SimpleFileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***** Simple IO with the File Type *****\n");
            //Change to a folder on your machine that you have read/write access to, or run as administrator

            //var fileName = $@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}temp{Path.
            //DirectorySeparatorChar}test.dat";

            var fileName = $@"C:\Users\ENVY\source\mynew.txt";

            // Make a new file on the C drive.
            FileInfo f = new FileInfo(fileName);

            FileStream fs = f.Create();
            // Use the FileStream object...
            // Close down file stream.
            fs.Close();



            //wrap the file stream in a using statement
            // Defining a using scope for file I/O
            FileInfo f1 = new FileInfo(fileName);
            using (FileStream fs1 = f1.Create())
            {
                // Use the FileStream object...
            }
            f1.Delete();




            //Notice that the FileInfo.Create() method returns a FileStream object, which exposes synchronous 
            //and asynchronous write / read operations to/ from the underlying file




            //            You can use the FileInfo.Open() method to open existing files, as well as to create new files with far
            //            more precision than you can with FileInfo.Create().
            //             Once the call to Open()
            //             completes, you are returned a FileStream object.Consider the following logic:






            // Make a new file via FileInfo.Open().
            FileInfo f2 = new FileInfo(fileName);
            using (FileStream fs2 = f2.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                // Use the FileStream object...
            }
            f2.Delete();





            // Get a FileStream object with read-only permissions.
            FileInfo f3 = new FileInfo(fileName);
            //File must exist before using OpenRead
            f3.Create().Close();
            using (FileStream readOnlyStream = f3.OpenRead())
            {
                // Use the FileStream object...
            }
            f3.Delete();



            // Now get a FileStream object with write-only permissions.
            FileInfo f4 = new FileInfo(fileName);
            using (FileStream writeOnlyStream = f4.OpenWrite())
            {
                // Use the FileStream object...
            }
            f4.Delete();



            // Get a StreamReader object.
            //If not on a Windows machine, change the file name accordingly
            FileInfo f5 = new FileInfo(fileName);
            //File must exist before using OpenText
            f5.Create().Close();
            using (StreamReader sreader = f5.OpenText())
            {
                // Use the StreamReader object...
            }
            f5.Delete();


            //As you will see shortly, the StreamReader type provides a way to read character data from the underlying file


            FileInfo f6 = new FileInfo(fileName);
            using (StreamWriter swriter = f6.CreateText())
            {
                // Use the StreamWriter object...
            }
            f6.Delete();


            FileInfo f7 = new FileInfo(fileName);
            using (StreamWriter swriterAppend = f7.AppendText())
            {
                // Use the StreamWriter object...
            }
            f7.Delete();















        }


















    }
}
    
