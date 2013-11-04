// 12. * Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class FutureAge
{
    static void Main()
    {    
        int yearBorn;
        while (true)
        {
            Console.WriteLine("Please enter the year you were born:");
            if ( int.TryParse(Console.ReadLine(), out yearBorn) && yearBorn > 1900 && yearBorn < DateTime.Now.Year)
            {
                break;
            }
            else
            {
                Console.WriteLine("Incorect data, please try again!");
            }
        }
        
        int yearsNow = DateTime.Now.Year - yearBorn;
        int futureAge = yearsNow + 10;
        Console.WriteLine("Your age now is {0} and you will be {1} years old after 10 years", yearsNow, futureAge);
        
    }
}
