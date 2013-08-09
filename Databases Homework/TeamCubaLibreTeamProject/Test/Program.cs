using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.IO;
using System.Data.OleDb;

namespace Test
{
    class Program
    {


        static void Main()
        {
            //using (ZipFile test = ZipFile.Read(@"../../Sample-Sales-Reports.zip"))
            //{
            //    foreach (ZipEntry item in test)
            //    {
            //        Console.WriteLine(test.Con);
            //    }
            //}

            using (ZipFile zip = ZipFile.Read(@"../../Sample-Sales-Reports.zip"))
            {
                //zip.ExtractAll(@"../../reports");

                foreach (ZipEntry e in zip)
                {
                    e.Extract();
                    Console.WriteLine(e.FileName[e.FileName.Length - 1]);

                    if (e.FileName[e.FileName.Length - 1] != '/')
                    {
                        string strAccessConn = string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    string.Format("Sample-Sales-Reports/{1}", zip.Name, e.FileName));

                        Console.WriteLine("{0}/{1}", zip.Name, e.FileName);

                        //Console.WriteLine(strAccessConn);

                        OleDbConnection myAccessConn = new OleDbConnection(strAccessConn);
                        myAccessConn.Open();
                        Console.WriteLine();
                        myAccessConn.Close();
                    }



                //    //if (true)
                //    //{
                //    //    Console.WriteLine("Zipfile: {0}", zip.Name);
                //    //    if ((zip.Comment != null) && (zip.Comment != ""))
                //    //        Console.WriteLine("Comment: {0}", zip.Comment);
                //    //    Console.WriteLine("\n{1,-22} {2,8}  {3,5}   {4,8}  {5,3} {0}",
                //    //                             "Filename", "Modified", "Size", "Ratio", "Packed", "pw?");
                //    //    Console.WriteLine(new String('-', 72));
                //    //}
                //    //Console.WriteLine("{1,-22} {2,8} {3,5:F0}%   {4,8}  {5,3} {0}",
                //    //                         e.FileName,
                //    //                         e.LastModified.ToString("yyyy-MM-dd HH:mm:ss"),
                //    //                         e.UncompressedSize,
                //    //                         e.CompressionRatio,
                //    //                         e.CompressedSize,
                //    //                         (e.UsesEncryption) ? "Y" : "N");

                //}
            }

            ExcelReader tester = new ExcelReader();
            tester.GetSubDirs(@"..\..\reports");
        }
    }
}
