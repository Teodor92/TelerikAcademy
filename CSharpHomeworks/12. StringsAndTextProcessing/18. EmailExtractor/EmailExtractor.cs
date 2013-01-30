using System;
using System.Text.RegularExpressions;

class EmailExtractor
{
    static void Main()
    {
        string text = Console.ReadLine();
        MatchCollection emails = Regex.Matches(text, @"([\w-\.]+)@((?:[\w]+\.)+)([a-zA-Z]{2,4})");
        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}
