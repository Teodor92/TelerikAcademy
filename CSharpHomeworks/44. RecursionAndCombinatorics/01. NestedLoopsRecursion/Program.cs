namespace NestedLoopsRecursion
{
    using System;

    public class Program
    {
        public static void NestedLoopsRec(int n, int[] current)
        {
            if (n == 0)
            {
                Console.WriteLine(string.Join(" ", current));
                return;
            }

            for (int i = 1; i <= current.Length; i++)
            {
                current[n - 1] = i;
                NestedLoopsRec(n - 1, current);
            }
        }

        public static void Main()
        {
            int loopsNumber = 4;
            NestedLoopsRec(loopsNumber, new int[loopsNumber]);
        }
    }
}
