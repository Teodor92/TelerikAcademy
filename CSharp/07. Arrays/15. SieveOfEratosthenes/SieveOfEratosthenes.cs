namespace _15.SieveOfEratosthenes
{
    using System;

    /// <summary>
    /// Write a program that finds all prime numbers 
    /// in the range [1...10 000 000]. Use the sieve 
    /// of Eratosthenes algorithm (find it in Wikipedia).
    /// </summary>
    public class SieveOfEratosthenes
    {
        internal static void Main()
        {
            var allNumbers = new bool[10000000];
            for (int i = 2; i < Math.Sqrt(allNumbers.Length); i++)
            {
                if (allNumbers[i] == false)
                {
                    for (int j = i * i; j < allNumbers.Length; j = j + i)
                    {
                        allNumbers[j] = true;
                    }
                }
            }

            for (int i = 2; i < allNumbers.Length; i++)
            {
                if (allNumbers[i] == false)
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine();
        }
    }
}
