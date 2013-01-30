using System;

class MathExpression
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());
        decimal firstPart, secondPart, thirdPart;
        firstPart = n * n + (1 / (m * p)) + 1337;
        secondPart = n - ( 128.523123123M * p );
        decimal mod = Math.Truncate((m % 180));
        thirdPart = (decimal)(Math.Sin((double)mod));
        Console.WriteLine(Math.Round((firstPart / secondPart) + thirdPart, 6));
    }
}
