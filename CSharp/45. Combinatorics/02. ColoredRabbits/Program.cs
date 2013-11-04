namespace _02.ColoredRabbits
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int allRabbits = int.Parse(Console.ReadLine());

            Dictionary<double, double> rabbits = new Dictionary<double, double>();
            for (int i = 0; i < allRabbits; i++)
            {
                double currentRabbit = double.Parse(Console.ReadLine()) + 1;

                if (rabbits.ContainsKey(currentRabbit))
                {
                    rabbits[currentRabbit]++;
                }
                else
                {
                    rabbits.Add(currentRabbit, 1);
                }
            }

            double result = 0;

            foreach (var rabbit in rabbits)
            {
                if (rabbit.Value == 1)
                {
                    result += rabbit.Key;
                }
                else
                {
                    result += Math.Ceiling(rabbit.Value / rabbit.Key) * rabbit.Key;
                }
            }

            Console.WriteLine(result);
        }
    }
}
