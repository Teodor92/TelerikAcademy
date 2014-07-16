namespace _03.Pier
{
    using System;

    public class Pier
    {
        internal static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split();
            var inputInNumbers = new int[input.Length];
            long sum = 0;

            for (int i = 0; i < n; i++)
            {
                inputInNumbers[i] = int.Parse(input[i]);
            }

            for (int i = 0; i < inputInNumbers.Length; i++)
            {
                sum = sum + inputInNumbers[i];
            }

            if (sum % 2 == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(1);
            }
        }
    }
}
