using System;

public class DayOfTheWeek
{
    public static void Main()
    {
        DayOfWeek today = DateTime.Today.DayOfWeek;
        Console.WriteLine("Today is {0}", today);
    }
}
