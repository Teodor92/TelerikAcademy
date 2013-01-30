using System;
using System.IO;
using System.Text.RegularExpressions;

class PrefixRemover
{
    static void Main()
    {
        using (StreamWriter fileWriter = new StreamWriter(@"../../Ex.11/OutResult.txt"))
        {
            using (StreamReader fileReader = new StreamReader(@"../../Ex.11/InOne.txt"))
            {
                string line = fileReader.ReadLine();
                while (line != null)
                {
                    fileWriter.WriteLine(Regex.Replace(line, @"\btest\w*\b", string.Empty));
                    line = fileReader.ReadLine();
                }
            }
        }
        
    }
}
