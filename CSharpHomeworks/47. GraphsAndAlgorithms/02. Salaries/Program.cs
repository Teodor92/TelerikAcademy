namespace Salaries
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int emploiesNumber = int.Parse(Console.ReadLine());

            Node[] allEmploies = new Node[emploiesNumber];

            for (int i = 0; i < allEmploies.Length; i++)
            {
                allEmploies[i] = new Node(i);
            }

            for (int i = 0; i < emploiesNumber; i++)
            {
                string employ = Console.ReadLine();

                for (int j = 0; j < employ.Length; j++)
                {
                    if (employ[j] == 'Y')
                    {
                        allEmploies[i].AddChild(allEmploies[j]);
                    }
                }
            }

            HashSet<Node> visited = new HashSet<Node>();

            decimal sum = 0;

            for (int i = 0; i < allEmploies.Length; i++)
            {
                if (!visited.Contains(allEmploies[i]))
                {
                    CalcSalaries(allEmploies[i], visited);
                }
            }

            for (int i = 0; i < allEmploies.Length; i++)
            {
                sum += allEmploies[i].Salary;
            }

            Console.WriteLine(sum);
        }

        public static decimal CalcSalaries(Node start, HashSet<Node> visited)
        {
            if (start.Childern == 0)
            {
                start.Salary = 1;
            }
            else
            {
                foreach (var item in start.ChildernList)
                {
                    if (visited.Contains(item))
                    {
                        start.Salary += item.Salary;
                    }
                    else
                    {
                        start.Salary += CalcSalaries(item, visited);
                    }
                }
            }

            visited.Add(start);

            return start.Salary;
        }
    }
}
