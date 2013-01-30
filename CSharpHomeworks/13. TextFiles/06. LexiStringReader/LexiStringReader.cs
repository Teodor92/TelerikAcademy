using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LexiStringReader
{
    public static void Main()
    {
        StreamReader fileReader = new StreamReader(@"..\..\Ex.6\InOne.txt");
        StreamWriter fileWriter = new StreamWriter(@"..\..\Ex.6\OutResult.txt");
        List<string> names = new List<string>();
        using (fileReader)
        {
            string line = fileReader.ReadLine();
            while (line != null)
            {
                names.Add(line.Trim());
                line = fileReader.ReadLine();
            }
        }

        names.Sort();

        using (fileWriter)
        {
            foreach (string item in names)
            {
                fileWriter.WriteLine(item);
            }    
        }
    }
}
