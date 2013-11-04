using System;

public class DaysBetween
{
    public static void Main()
    {
        Console.WriteLine("Enter 2 dates in day.month.year format.");
        string[] firstDate = Console.ReadLine().Split('.');
        string[] secondDate = Console.ReadLine().Split('.');
        DateTime firstDayObj = new DateTime(int.Parse(firstDate[2]),int.Parse(firstDate[1]),int.Parse(firstDate[0]));
        DateTime secondDayObj = new DateTime(int.Parse(secondDate[2]), int.Parse(secondDate[1]), int.Parse(secondDate[0]));
        int numberOfDaysBetween = Math.Abs((firstDayObj - secondDayObj).Days);
        Console.WriteLine(numberOfDaysBetween);
    }
}
