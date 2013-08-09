namespace StringVariations
{
    using System;

    public class Program
    {
        public static void GenerateStringVaritaions(int k, string[] set, string[] currentCombo)
        {
            if (k == 0)
            {
                Console.WriteLine(string.Join(" ", currentCombo));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                currentCombo[k - 1] = set[i];
                GenerateStringVaritaions(k - 1, set, currentCombo);
            }
        }

        public static void Main(string[] args)
        {
            int k = 2;
            GenerateStringVaritaions(k, new string[3] { "hi", "a", "b" }, new string[k]);
        }
    }
}
