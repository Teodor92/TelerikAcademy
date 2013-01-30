using System;

public class Matrix
{
    public static void PrintMatrix(int[,] matrix)
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

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] myMatrix = new int[n, n];
        int counter = 1;
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                myMatrix[row, col] = counter;
                counter++;
                //// matrix[i, j] = i + 1 + size*j;  
            }
        }

        PrintMatrix(myMatrix);
    }
}
