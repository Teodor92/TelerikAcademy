namespace _12.BitModiffer
{
    using System;

    /// <summary>
    /// We are given integer number n, value v (v=0 or 1) and a position p. 
    /// Write a sequence of operators that modifies n to hold the value v at the 
    /// position p from the binary representation of n.
    /// Example: n = 5 (00000101), p=3, v=1  13 (00001101)
    /// n = 5 (00000101), p=2, v=0  1 (00000001)
    /// </summary>
    public class BitModiffer
    {
        internal static void Main()
        {
            int nthNumber = 33;
            byte bitValue = 1;
            byte position = 2;
            int mask = bitValue << position;
            if ((nthNumber & mask) != 0)
            {
                // the bit is 1
                if (bitValue == 0)
                {
                    nthNumber = nthNumber & (~mask);
                    Console.WriteLine(nthNumber);
                }
                else
                {
                    Console.WriteLine(nthNumber);
                }
            }
            else
            { 
                // the bit is 0
                if (bitValue == 1)
                {
                    nthNumber = nthNumber | mask;
                    Console.WriteLine(nthNumber);
                }
                else
                {
                    Console.WriteLine(nthNumber);
                }
            }
        }
    }
}
