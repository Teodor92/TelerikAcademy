/* * Write a program that exchanges bits {p, p+1, …, p+k-1) 
 * with bits {q, q+1, …, q+k-1} of 
 * given 32-bit unsigned integer.
 */

using System;
using System.Collections.Generic;

class HarderBitExchange
{
    static void Main()
    {
        int number = 65280;
        byte p = 2;
        byte q = 9;
        byte k = 2;
        // turning the number in bin system
        int[] numberInBin = new int[32];
        for (int i = 0; i < numberInBin.Length; i++ )
        {
            if (number == 0)
            {
                break;
            }
            numberInBin[i] = number % 2;
            number = number / 2;
        }
        // Printing the list
        for (int i = 0; i < numberInBin.Length; i++)
        {
            Console.Write(numberInBin[i]);
        }
        Console.WriteLine();
        //Making the change
        for (int i = 0; i < k; i++)
        {
            int temp = 0;
            temp = numberInBin[p];
            numberInBin[p] = numberInBin[q];
            numberInBin[q] = temp;
            p++;
            q++;
        }
        // Printing the edited list
        //numberInBin.Reverse();
        Array.Reverse(numberInBin);
        for (int i = 0; i < numberInBin.Length; i++)
        {
            Console.Write(numberInBin[i]);
        }
        Console.WriteLine();
    }
}
