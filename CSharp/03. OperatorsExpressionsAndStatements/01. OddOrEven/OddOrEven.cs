namespace _01.OddOrEven
{
    using System;

    /// <summary>
    /// Write an expression that checks if given integer is odd or even.
    /// </summary>
    public class OddOrEven
    {
        internal static void Main()
        {
            while (true)
            {
                int number;
                Console.WriteLine("Enter an intiger nummber:");
                bool validNumber = int.TryParse(Console.ReadLine(), out number);

                if (validNumber)
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
                    continue;
                }

                break;
            }
        }
    }
}
