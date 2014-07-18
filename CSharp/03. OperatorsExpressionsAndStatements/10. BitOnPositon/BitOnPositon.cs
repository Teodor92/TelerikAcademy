namespace _10.BitOnPositon
{
    using System;

    /// <summary>
    /// Write a boolean expression that returns if the bit at 
    /// position p (counting from 0) in a given 
    /// integer number v has value of 1. Example: v=5; p=1  false.
    /// </summary>
    public class BitOnPositon
    {
        internal static void Main()
        {
            int position = 4;
            int bitType = 1;
            int number = 1567;
            bool isGivenBit = false;
            int newNumber = (number >> position) & 1;
            if (newNumber == bitType)
            {
                isGivenBit = true;
            }

            Console.WriteLine("The bit on position {0} is {1} : {2}", position, bitType, isGivenBit);
        }
    }
}
