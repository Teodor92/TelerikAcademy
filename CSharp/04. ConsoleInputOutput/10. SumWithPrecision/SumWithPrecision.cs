namespace _10.SumWithPrecision
{
    using System;

    /// <summary>
    /// Write a program to calculate the sum 
    /// (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
    /// </summary>
    public class SumWithPrecision
    {
        internal static void Main()
        {
            decimal sum = 1;
            decimal oldSum = -1;
            for (decimal i = 2; i <= 9950; i++)
            {
                if (i % 2 == 0)
                {
                    sum = sum + (1 / i);
                }
                else
                {
                    sum = sum - (1 / i);
                }

                if ((sum - oldSum) == 0.001M)
                {
                    break;
                }

                oldSum = sum;
            }

            Console.WriteLine(sum);
        }
    }
}