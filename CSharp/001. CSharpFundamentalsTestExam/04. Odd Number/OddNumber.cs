namespace _04.Odd_Number
{
    using System;

    public class OddNumber
    {
        internal static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var number = 0L;
            var odd = 0L;

            for (long i = 1; i <= lines; i++)
            {
                number = long.Parse(Console.ReadLine());

                odd = number ^ odd;
            }

            Console.WriteLine(odd);
        }
    }
}
