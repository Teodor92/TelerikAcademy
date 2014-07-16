namespace _06.MinDigit
{
    using System;

    public class MinDigit
    {
        internal static void Main()
        {
            var input = Console.ReadLine();
            var minNumber = int.MaxValue;
            var inputInNumbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputInNumbers[i] = Convert.ToInt32(input[i]) - 48;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (inputInNumbers[i] < minNumber && inputInNumbers[i] != 0)
                {
                    minNumber = inputInNumbers[i];
                }
            }

            Console.WriteLine(minNumber);
        }
    }
}
