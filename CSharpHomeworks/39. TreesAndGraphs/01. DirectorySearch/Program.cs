namespace DirectorySearch
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            ExeFilePrinter exePrinter = new ExeFilePrinter();

            exePrinter.GetSubDirs(@"C:\");
        }
    }
}
