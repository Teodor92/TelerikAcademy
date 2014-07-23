namespace _01._2.MatrixTwo
{
    using System;

    public class MatrixTwo
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            int counter = 1;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < matrix.GetLength(1); row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = matrix.GetLength(1) - 1; row > -1; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
