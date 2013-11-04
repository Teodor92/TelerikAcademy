/* Write a program to calculate n! for each n in 
 * the range [1..100]. Hint: Implement first a 
 * method that multiplies a number represented 
 * as array of digits by given integer number. 
 */

using System;
using System.Numerics;

public class BigFactorial
{
    public static void Main()
    {
        for (int i = 1; i < 101; i++)
        {
            Console.WriteLine(FactorialCalc(i));   
        }
    }

    private static BigInteger FactorialCalc(int number)
    {
        BigInteger product = 1;
        for (int i = number; i > 0; i--)
        {
            product = product * i;
        }

        return product;
    }
}
