using System;
using System.IO;
using System.Text.RegularExpressions;

public class XMLExtractor
{
    public static void Main()
    {
        StreamReader fileReader = new StreamReader(@"..\..\Ex.10\InOne.txt");

        string allText = string.Empty;

        using (fileReader)
        {
            allText = fileReader.ReadToEnd();
        }

        MatchCollection xml = Regex.Matches(allText, @"(?<=^|>)[^><]+?(?=<|$)");
        foreach (var item in xml)
        {
            Console.WriteLine(item.ToString().Trim());
        }
    }
}
