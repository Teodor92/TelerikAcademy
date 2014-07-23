namespace _01._4.MatrixFour
{
    using System;

    public class MatrixFour
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            int ending = size;
            int start = 0;
            int counter = 1;
            do
            {
                for (int i = start; i < ending; i++)
                {
                    matrix[i, start] = counter;
                    counter++;
                }

                for (int j = start + 1; j < ending; j++)
                {
                    matrix[ending - 1, j] = counter;
                    counter++;
                }

                for (int k = ending - 2; k >= start; k--)
                {
                    matrix[k, ending - 1] = counter;
                    counter++;
                }

                for (int p = ending - 2; p >= start + 1; p--)
                {
                    matrix[start, p] = counter;
                    counter++;
                }

                start++;
                ending--;
            }
            while (ending - start > 0);

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
