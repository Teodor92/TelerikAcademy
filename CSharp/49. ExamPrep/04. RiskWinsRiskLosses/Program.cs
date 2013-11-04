namespace RiskWinsRiskLosess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            string startCombo = Console.ReadLine();
            string endCombo = Console.ReadLine();

            int numberOfFrobidenCombos = int.Parse(Console.ReadLine());
            HashSet<string> visited = new HashSet<string>();

            for (int i = 0; i < numberOfFrobidenCombos; i++)
            {
                visited.Add(Console.ReadLine());
            }

            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string, int>(startCombo, 0));
            visited.Add(startCombo);

            while (queue.Count > 0)
            {
                Tuple<string, int> curentCombo = queue.Dequeue();

                if (curentCombo.Item1 == endCombo)
                {
                    Console.WriteLine(curentCombo.Item2);
                    return;
                }

                var currentNumber = new StringBuilder(curentCombo.Item1);

                for (int i = 0; i < 5; i++)
                {
                    int digit = curentCombo.Item1[i] - '0';
                    digit++;

                    if (digit == 10)
                    {
                        digit = 0;
                    }

                    currentNumber[i] = (char)(digit + '0');

                    string newNode = currentNumber.ToString();

                    if (!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string, int>(newNode, curentCombo.Item2 + 1));
                    }

                    currentNumber[i] = curentCombo.Item1[i];
                }

                for (int i = 0; i < 5; i++)
                {
                    int digit = curentCombo.Item1[i] - '0';
                    digit--;

                    if (digit == -1)
                    {
                        digit = 9;
                    }

                    currentNumber[i] = (char)(digit + '0');

                    string newNode = currentNumber.ToString();

                    if (!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string, int>(newNode, curentCombo.Item2 + 1));
                    }

                    currentNumber[i] = curentCombo.Item1[i];
                }
            }

            Console.WriteLine(-1);
        }
    }
}
