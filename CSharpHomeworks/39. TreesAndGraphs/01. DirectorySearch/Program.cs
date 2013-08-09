namespace DirectorySearch
{
    /*
     * Write a program to traverse the directory C:\WINDOWS and all 
     * its subdirectories recursively and to display 
     * all files matching the mask *.exe. Use the class System.IO.Directory. 
     */

    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            ExeFilePrinter exePrinter = new ExeFilePrinter();

            exePrinter.GetSubDirs(@"D:\");
        }
    }
}
