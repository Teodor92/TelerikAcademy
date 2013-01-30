/* Write a program that, depending on the user's choice 
 * inputs int, double or string variable. If the variable 
 * is integer or double, increases it with 1. If the variable 
 * is string, appends "*" at its end. The program must show the 
 * value of that variable as a console output. Use switch statement.
 */

using System;

class ChoiceForInput
{
    static void Main()
    {
        Console.WriteLine("Enter 1 for int, 2 for double, and 3 for string");
        sbyte choice = sbyte.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1: int firstCohise = int.Parse(Console.ReadLine()); 
                Console.WriteLine(firstCohise + 1); 
                break;
            case 2: double secondCohise = double.Parse(Console.ReadLine()); 
                Console.WriteLine(secondCohise + 1); 
                break;
            case 3: string thirdCohise = Console.ReadLine(); 
                Console.WriteLine(thirdCohise + "*"); 
                break;
            default: Console.WriteLine("Problem, problem"); 
                break;
        }
    }
}
