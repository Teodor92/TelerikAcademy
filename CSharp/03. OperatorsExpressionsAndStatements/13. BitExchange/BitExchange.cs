namespace _13.BitExchange
{
    using System;

    /// <summary>
    /// Write a program that exchanges bits 3, 4 and 5 
    /// with bits 24, 25 and 26 of given 32-bit unsigned integer.
    /// </summary>
    public class BitExchange
    {
        internal static void Main()
        {
            uint number = 1073709056;
            uint mask = 7;

            // Getting the 3, 4, 5 bits
            uint firstTreeBits = number & (mask << 3);

            // Getting the 24, 25, 26 bits
            uint secondTreeBits = number & (mask << 24);

            // Moving the bits to there correct position
            firstTreeBits = firstTreeBits << 21;
            secondTreeBits = secondTreeBits >> 21;

            // Replaceing the 3,4,5 bits in the number with 0;
            number = number & (~(mask << 3));
            Console.WriteLine(Convert.ToString(number, 2));

            // Replaceing the 24,25,26 bits in the number with 0;
            number = number & (~(mask << 24));
            Console.WriteLine(Convert.ToString(number, 2));

            // Inserting the reversed bits
            number = number | firstTreeBits;
            Console.WriteLine(Convert.ToString(number, 2));
            number = number | secondTreeBits;
            Console.WriteLine(Convert.ToString(number, 2));
        }
    }
}
