namespace _03.BiggestOfThree
{
    using System;

    /// <summary>
    /// Write a program that finds the biggest 
    /// of three integers using nested if statements.
    /// </summary>
    public class BiggestOfThree
    {
        internal static void Main()
        {
            int firstNum = 3;
            int secondNum = 5;
            int thirdNum = 8;
            int biggest = 0;
            biggest = GetBigger(firstNum, secondNum);
            biggest = GetBigger(biggest, thirdNum);
            Console.WriteLine(biggest);
        }

        private static int GetBigger(int first, int second)
        {
            if (first > second)
            {
                return first;
            }

            return second;
        }
    }
}
