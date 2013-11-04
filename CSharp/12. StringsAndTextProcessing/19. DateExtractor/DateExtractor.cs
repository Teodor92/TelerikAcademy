using System;
using System.Globalization;
using System.Text.RegularExpressions;

class DateExtractor
{
    static void Main()
    {
        Console.WriteLine("The dates must be in DD.MM.YYYY format!");
        string text = Console.ReadLine();

        MatchCollection dates = Regex.Matches(text, @"\b[0-9]{2}.[0-9]{2}.[0-9]{4}\b");

        foreach (var date in dates)
        {
            DateTime currDate = DateTime.Parse(date.ToString());
            Console.WriteLine(currDate.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat));
        }
    }
}
