namespace _001.BinVectorsTest
{
    using System;

    public class Program
    {
        public static void GenVector(int index, int[] vector)
        {
            if (index == -1)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                vector[index] = i;
                GenVector(index - 1, vector);
            }
        }

        public static void Main()
        {
            GenVector(5, new int[6]);
        }
    }
}
