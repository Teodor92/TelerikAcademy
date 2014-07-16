namespace _16.Icecream
{
    using System;

    public class Icecream
    {
        internal static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var numberOfElefants = int.Parse(input[0]);
            var number = input[1];
            var counter = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != '0')
                {
                    counter++;
                }
            }

            Console.WriteLine(numberOfElefants - counter);
        }
    }
}
