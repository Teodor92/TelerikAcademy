namespace _11.SimpleMatrix
{
    using System;

    public class SimpleMatrix
    {
        internal void Main()
        {
            Console.WriteLine("Enter a Number:");
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int start = row + 1;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = start;
                    start++;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
