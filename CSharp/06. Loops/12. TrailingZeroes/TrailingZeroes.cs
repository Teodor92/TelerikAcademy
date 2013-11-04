/* Write a program that calculates for given N how many trailing zeros present 
 * at the end of the number N!. Examples:
	N = 10  N! = 3628800  2
	N = 20  N! = 2432902008176640000  4
	Does your program work for N = 50 000?
	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
 */

using System;
using System.Numerics;

class TrailingZeroes
{
    static void Main()
    {
        Console.WriteLine("Enter a positive integer number N: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;
        Console.WriteLine();
        BigInteger trailingZeroes = 0;
        int sum = 5; // n/5 + n/25 + n/125 + … = the number of trailing zeroes in N!

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        Console.WriteLine(factorial);

        while (n >= sum)
        {
            trailingZeroes += (n / sum);
            sum *= 5;
        }
        Console.WriteLine("The number of the trailing zeroes at the end of ({0}!) is: {1}\n", n, trailingZeroes);
    }
}