namespace _01._3.MatrixThree
{
    using System;

    public class MatrixThree
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            int counter = 1;
            int counterTwo = 16;
            int up = 0;
            for (int row = matrix.GetLength(0) - 1; row > -1; row--)
            {
                int currentRow = row;
                int currentCol = 0;
                matrix[currentRow, currentCol] = counter;
                counter++;
                while (true)
                {
                    currentRow = currentRow + 1;
                    currentCol = currentCol + 1;
                    if (currentCol < 0 || currentRow < 0 || currentCol > size - 1 || currentRow > size - 1)
                    {
                        break;
                    }

                    matrix[currentRow, currentCol] = counter;
                    counter++;
                }

                currentRow = up;
                currentCol = size - 1;
                if (currentCol > 0)
                {
                    matrix[currentRow, currentCol] = counterTwo;
                    counterTwo--;
                    while (true)
                    {
                        currentRow = currentRow - 1;
                        currentCol = currentCol - 1;
                        if (currentCol < 0 || currentRow < 0 || currentCol > size - 1 || currentRow > size - 1)
                        {
                            break;
                        }

                        matrix[currentRow, currentCol] = counterTwo;
                        counterTwo--;
                    }
                }

                up++;
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
