namespace GreedyDwarf
{
    using System;

    public class Program
    {
        private static bool CheckIfInVally(int point, int vallyLength)
        {
            if (point >= 0 && point < vallyLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int GetSumFromPattern(int[] vally, int[] pattern)
        {
            int sum = 0;
            bool[] visited = new bool[vally.Length];

            sum += vally[0];
            visited[0] = true;
            int currentPos = 0;

            while (true)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    int nextStep = currentPos + pattern[i];

                    if (CheckIfInVally(nextStep, vally.Length) && !visited[nextStep])
                    {
                        sum += vally[nextStep];
                        visited[nextStep] = true;
                        currentPos = nextStep;
                    }
                    else
                    {
                        return sum;
                    }
                }   
            }
        }

        public static void Main(string[] args)
        {
            // vally parse
            string[] rawNumbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] vallyNumbers = new int[rawNumbers.Length];

            for (int i = 0; i < vallyNumbers.Length; i++)
            {
                vallyNumbers[i] = int.Parse(rawNumbers[i]);
            }

            int numberOfPatters = int.Parse(Console.ReadLine());
            int maxSum = int.MinValue;

            for (int i = 0; i < numberOfPatters; i++)
            {
                rawNumbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] patternNumbers = new int[rawNumbers.Length];

                for (int j = 0; j < patternNumbers.Length; j++)
                {
                    patternNumbers[j] = int.Parse(rawNumbers[j]);
                }

                int sum = GetSumFromPattern(vallyNumbers, patternNumbers);

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
