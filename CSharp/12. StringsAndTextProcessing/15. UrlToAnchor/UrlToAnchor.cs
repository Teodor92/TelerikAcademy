using System;
using System.Text.RegularExpressions;

class UrlToAnchor
{
    static void Main()
    {
        string text = Console.ReadLine();

        // TODO Fix later .... maybe
        // There is a better reg expresion, BUT im too lazy at the moment!

        text = Regex.Replace(text, @"<a href=""", @"[URL=");
        text = Regex.Replace(text, @""">", @"]");
        text = Regex.Replace(text, @"</a>", @"[/URL]");
        Console.WriteLine(text);
    }
}
