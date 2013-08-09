namespace CombinationsWithDuplicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void GenerateDuplicateCombinatios(int k, int[] set, int[] currentCombo, int startNum)
        {
            if (k == 0)
            {
                Console.WriteLine(string.Join(" ", currentCombo));
                return;
            }

            for (int i = startNum; i < set.Length; i++)
            {
                currentCombo[k - 1] = set[i];
                GenerateDuplicateCombinatios(k - 1, set, currentCombo, i);
            }
        }

        public static void Main(string[] args)
        {
            int k = 2;
            GenerateDuplicateCombinatios(k, new int[3] { 1, 2, 3 }, new int[k], 0);
        }
    }
}
