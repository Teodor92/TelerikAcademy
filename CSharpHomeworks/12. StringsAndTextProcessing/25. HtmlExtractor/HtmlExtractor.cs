using System;
using System.IO;
using System.Text.RegularExpressions;

public class HtmlExtractor
{
    public static void Main()
    {
        string allText = Console.ReadLine();

        MatchCollection xml = Regex.Matches(allText, @"(?<=^|>)[^><]+?(?=<|$)");
        foreach (var item in xml)
        {
            Console.WriteLine(item);
        }
    }
}