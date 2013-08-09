namespace _04.Permutations
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] set = new int[n];

            for (int i = 0; i < set.Length; i++)
            {
                set[i] = i + 1;
            }

            GeneratePermutations(set, 0);
        }

        public static void GeneratePermutations<T>(T[] set, int k)
        {
            if (k >= set.Length)
            {
                PrintSet(set);
            }
            else
            {
                GeneratePermutations(set, k + 1);
                for (int i = k + 1; i < set.Length; i++)
                {
                    Swap(ref set[k], ref set[i]);
                    GeneratePermutations(set, k + 1);
                    Swap(ref set[k], ref set[i]);
                }
            }
        }

        public static void PrintSet<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        public static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
