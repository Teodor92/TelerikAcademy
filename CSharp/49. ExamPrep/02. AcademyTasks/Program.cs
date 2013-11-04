namespace AcademyTasks
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static List<int> tasks = new List<int>();
        private static int variety;
        private static int maxIndex;

        public static void Main(string[] args)
        {
            string tasksAsStringLine = Console.ReadLine();
            var tasksAsString = tasksAsStringLine.Split(
                new char[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var taskAsString in tasksAsString)
            {
                tasks.Add(int.Parse(taskAsString));
            }

            variety = int.Parse(Console.ReadLine());

            Console.WriteLine(SolveWithDP());
        }

        private static int SolveWithDP()
        {
            int minCount = tasks.Count;
            for (int i = 0; i < tasks.Count - 1; i++)
            {
                for (int j = i + 1; j < tasks.Count; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= variety)
                    {
                        int count = 0;
                        count += (i + 1) / 2; // from 0 to i, inclusive 0
                        count += (j - i + 1) / 2 + 1; // from i to j, inclusive i and j
                        minCount = Math.Min(minCount, count);
                    }
                }
            }

            return minCount;
        }
    }
}