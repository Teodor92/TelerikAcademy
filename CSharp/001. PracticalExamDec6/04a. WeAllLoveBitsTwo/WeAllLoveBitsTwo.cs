namespace _04a.WeAllLoveBitsTwo
{
    using System;
    using System.Collections.Generic;

    public class WeAllLoveBitsTwo
    {
        internal static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                var bits = new List<int>();
                while (true)
                {
                    if (input == 0)
                    {
                        break;
                    }

                    bits.Add(input % 2);
                    input = input / 2;
                }

                bits.Reverse();
                int sum = 0;

                for (int j = 0; j < bits.Count; j++)
                {
                    sum = sum + (int)Math.Pow(2 * bits[j], j);
                }

                Console.WriteLine(sum);
            }
        }
    }
}
