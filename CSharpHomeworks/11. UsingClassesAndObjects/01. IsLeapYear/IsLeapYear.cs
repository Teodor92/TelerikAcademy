using System;

public class IsLeapYear
{
    public static void Main()
    {
        Console.WriteLine("Enter the date in YYYY/MM/DD format");
        string date = Console.ReadLine();
        DateTime now = DateTime.Parse(date);
        if (now.Year % 4 == 0)
        {
            Console.WriteLine("The year is leap");
        }
        else
        {
            Console.WriteLine("The year is not leap");
        }
    }
}
