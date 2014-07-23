namespace _08.GreatestCommonDivisor
{
    using System;

    internal class GreatestCommonDivisor
    {
        internal static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            Console.WriteLine(GetGreatestCommonDivisor(firstNum, secondNum));
        }

        private static int GetGreatestCommonDivisor(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return GetGreatestCommonDivisor(b, a % b);
        }
    }
}
