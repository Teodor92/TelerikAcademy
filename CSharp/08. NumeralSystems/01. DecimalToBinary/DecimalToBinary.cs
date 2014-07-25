namespace _01.DecimalToBinary
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program to convert decimal 
    /// numbers to their binary representation.
    /// </summary>
    public class DecimalToBinary
    {
        internal static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var inBinary = new List<int>();
            while (number > 0)
            {
                inBinary.Add(number % 2);
                number = number / 2;
            }

            inBinary.Reverse();
            for (int i = 0; i < inBinary.Count; i++)
            {
                Console.Write("{0} ", inBinary[i]);
            }

            Console.WriteLine();
        }
    }
}
