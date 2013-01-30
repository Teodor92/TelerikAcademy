using System;

class HoursAfter
{
    static void Main()
    {
        Console.WriteLine("Enter date and hour in day.month.year hour:minute:second ");
        char[] splitChars = {' ','.',':'};
        string[] today = Console.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
        DateTime todayDate = new DateTime(int.Parse(today[2]), int.Parse(today[1]), int.Parse(today[0]), int.Parse(today[3]), int.Parse(today[4]), int.Parse(today[5]));
        todayDate = todayDate.AddHours(6);
        todayDate = todayDate.AddMinutes(30);
        Console.WriteLine(todayDate);
    }
}
