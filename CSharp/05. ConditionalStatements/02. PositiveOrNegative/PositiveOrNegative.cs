/* Write a program that shows the sign (+ or -) 
 * of the product of three real numbers without 
 * calculating it. Use a sequence of if statements.
 */
using System;

class PositiveOrNegative
{
    public static int SignCheker(int number)
    {
        if (number > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());
        int sign = 0;
        sign = sign + SignCheker(firstNum);
        sign = sign + SignCheker(secondNum);
        sign = sign + SignCheker(thirdNum);
        if (firstNum == 0 || secondNum == 0 || thirdNum == 0)
        {
            Console.WriteLine("The product is zero");
        }
        else if (sign == 1 || sign == 3)
        {
            Console.WriteLine("The product is positive");
        }
        else
        {
            Console.WriteLine("The product is negative");
        }
    }
}
