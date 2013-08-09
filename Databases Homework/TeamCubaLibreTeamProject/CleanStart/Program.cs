using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStart
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipInputStream zip = new ZipInputStream(File.OpenRead(@"../../Sample-Sales-Reports.zip"));
            ZipEntry item;
            while ((item = zip.GetNextEntry()) != null)
            {
                Zip
                Console.WriteLine();
            }
        }
    }
}
