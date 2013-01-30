/* Write an expression that checks if given positive 
 * integer number n (n ≤ 100) is prime. E.g. 37 is prime.
 */

using System;

class IfPrime
{
    static void Main()
    {
        int number = 13;
        int counter = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                counter++;
            }
        }
        if (counter == 2)
        {
            Console.WriteLine("The number is prime");
        }
        else
        {
            Console.WriteLine("The number is NOT prime");
        }
    }
}
