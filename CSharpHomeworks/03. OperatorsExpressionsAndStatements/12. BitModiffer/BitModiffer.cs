/* We are given integer number n, value v (v=0 or 1) and a position p. 
 * Write a sequence of operators that modifies n to hold the value v at the 
 * position p from the binary representation of n.
	Example: n = 5 (00000101), p=3, v=1  13 (00001101)
	n = 5 (00000101), p=2, v=0  1 (00000001)
*/

using System;

class BitModiffer
{
    static void Main()
    {
        int nNumber = 33;
        byte bitValue = 1;
        byte position = 2;
        int mask = bitValue << position;
        if ((nNumber & mask) != 0)
        {
            // the bit is 1
            if (bitValue == 0)
            {
                nNumber = nNumber & (~(mask));
                Console.WriteLine(nNumber);
            }
            else
            {
                Console.WriteLine(nNumber);
            }
        }
        else
        { 
            // the bit is 0
            if (bitValue == 1)
            {
                nNumber = nNumber | mask;
                Console.WriteLine(nNumber);
            }
            else
            {
                Console.WriteLine(nNumber);
            }

        }
    }
}
