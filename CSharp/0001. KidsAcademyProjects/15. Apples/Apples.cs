namespace _15.Apples
{
    using System;

    public class Apples
    {
        internal static void Main()
        {
            var input = Console.ReadLine().Split();
            var y = int.Parse(input[0]);
            var k = int.Parse(input[1]);
            var n = int.Parse(input[2]);
            var rangeOfX = n - y;
            var counter = 0;

            for (int i = 1; i < rangeOfX + 1; i++)
            {
                if ((i + y) % k == 0)
                {
                    Console.Write("{0} ", i);
                    counter++;
                }
            }

            if (counter == 0 || rangeOfX < 0)
            {
                Console.WriteLine(-1);
            }

            Console.WriteLine();
        }
    }
}
