namespace StringSubsets
{
    using System;

    public class Program
    {
        public static void GenerateStringSubsets(int k, string[] set, string[] currentCombo, int nextNumber)
        {
            if (k == 0)
            {
                Console.WriteLine(string.Join(" ", currentCombo));
                return;
            }

            for (int i = nextNumber; i < set.Length; i++)
            {
                currentCombo[k - 1] = set[i];
                GenerateStringSubsets(k - 1, set, currentCombo, i + 1);
            }
        }

        public static void Main(string[] args)
        {
            int k = 2;
            GenerateStringSubsets(k, new string[3] { "test", "rock", "fun" }, new string[k], 0);
        }
    }
}
