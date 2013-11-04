/* Write a boolean expression for finding if 
 * the bit 3 (counting from 0) of a given integer is 1 or 0.
 */

using System;

class ThirdBit
{
    static void Main()
    {
        int number = 7;
        number = number >> 3;
        int mask = 1;
        int maskAndNumber = number & mask;
        if (maskAndNumber == 1)
        {
            Console.WriteLine("The bit on position 3 is 1");
        }
        else
        {
            Console.WriteLine("The bit on position 3 is 0");
        }
    }
}
