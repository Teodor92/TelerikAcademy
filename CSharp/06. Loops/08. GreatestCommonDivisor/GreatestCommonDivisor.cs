using System;

class GreatestCommonDivisor
{
    static int gcd(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        else
        {
            return gcd(b, a%b);
        }
    }
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        Console.WriteLine(gcd(firstNum, secondNum)); 
    }
}
