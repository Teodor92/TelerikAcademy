using System;

class MatrixHarder
{
    static void Main()
    {
        Console.WriteLine("Enter a Number:");
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];
        int start = 0;
        int end = size;
        int numbers = 1;
        while (end - start >= 1)
        {
            for (int i = start; i < end; i++)
            {
                matrix[start, i] = numbers;
                numbers++;
            }
            for (int p = start + 1; p < end; p++)
            {
                matrix[p, end - 1] = numbers;
                numbers++;
            }
            for (int j = end - 2; j >= start; j--)
            {
                matrix[end - 1, j] = numbers;
                numbers++;
            }
            for (int x = end - 2; x >= start + 1; x--)
            {
                matrix[x, start] = numbers;
                numbers++;
            }
            start = start + 1;
            end = end - 1;
        }
        // printing the matrix
        for (int counter = 0; counter < size; counter++)
        {
            for (int counterTwo = 0; counterTwo < size; counterTwo++)
            {
                Console.Write(matrix[counter, counterTwo] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
