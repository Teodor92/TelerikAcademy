/* Write an expression that extracts from a given integer i 
 * the value of a given bit number b. Example: i=5; b=2  value=1.
 */

using System;

class BitExtract
{
    static void Main(string[] args)
    {
        int iNumber = 36;
        int bBitNumber = 4;
        byte value = 1;
        int newNumber = (iNumber >> bBitNumber) & 1;
        if (newNumber == 0)
        {
            value = 0;
        }
        else
        {
            value = 1;
        }
        Console.WriteLine("The value ot the {0} - th bit is {1}", bBitNumber, value);
    }
}
