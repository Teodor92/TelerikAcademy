namespace _01.MathExpression
{
    using System;

    public class MathExpression
    {
        internal static void Main()
        {
            var n = decimal.Parse(Console.ReadLine());
            var m = decimal.Parse(Console.ReadLine());
            var p = decimal.Parse(Console.ReadLine());
            var firstPart = (n * n) + (1 / (m * p)) + 1337;
            var secondPart = n - (128.523123123M * p);
            var mod = Math.Truncate(m % 180);
            var thirdPart = (decimal)Math.Sin((double)mod);

            Console.WriteLine(Math.Round((firstPart / secondPart) + thirdPart, 6));
        }
    }
}
