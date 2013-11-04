namespace NoDuplicatesCombinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Program
    {
        public static void GenerateNoDuplicateCombinatios(int k, int[] set, int[] currentCombo, int nextNumber)
        {
            if (k == 0)
            {
                Console.WriteLine(string.Join(" ", currentCombo));
                return;
            }

            for (int i = nextNumber; i < set.Length; i++)
            {
                currentCombo[k - 1] = set[i];
                GenerateNoDuplicateCombinatios(k - 1, set, currentCombo, i + 1);
            }
        }

        public static void Main(string[] args)
        {
            int k = 2;
            GenerateNoDuplicateCombinatios(k, new int[3] { 1, 2, 3 }, new int[k], 0);
        }
    }
}
