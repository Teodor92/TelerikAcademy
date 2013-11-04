/*
 * Write an expression that checks if given integer is odd or even.
 */

using System;

class OddOrEven
{
    static void Main()
    {
        int number;
        Console.WriteLine("Enter an intiger nummber:");
        bool ValidNumber = int.TryParse(Console.ReadLine(), out number);
        if (ValidNumber == true)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine("The number is even!");
            }
            else
            {
                Console.WriteLine("The number is odd!");
            }
        }
        else
        {
            Console.WriteLine("Wrong Number!");
            Main();
        }
    }
}
