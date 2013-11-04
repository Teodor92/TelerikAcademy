using System;

public class LargestArea
{
    public static int CurrentArea = 0;

    public static int[,] Dirs = new int[,]
    {
        { 1, 0 }, // down
        { 0, 1 }, // right
        { -1, 0 }, // up
        { 0, -1 } // left
    };

    public static bool IsPassable(int[,] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }

    public static void DepthFirstSearch(int[,] matrix, int row, int col)
    {
        int value = matrix[row, col];

        // set visited = 0
        matrix[row, col] = 0;
        CurrentArea++;

        // directions change
        for (int i = 0; i < Dirs.GetLength(0); i++)
        {
            int newRow = row + Dirs[i, 0];
            int newCol = col + Dirs[i, 1];

            // Out of array check and next cell value checks 
            if (IsPassable(matrix, newRow, newCol) && matrix[newRow, newCol] == value)
            {
                DepthFirstSearch(matrix, newRow, newCol);
            }
        }
    }

    public static void Main()
    {
        // testing input 
        int[,] matrix = 
        {
            { 1, 3, 2, 2, 2, 4 },
            { 3, 3, 3, 2, 4, 4 },
            { 4, 3, 1, 2, 3, 3 },
            { 4, 3, 1, 3, 3, 1 },
            { 4, 3, 3, 3, 1, 1 }
        };
        int bestArea = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] != 0)
                {
                    // = 0 before every call of DFS
                    CurrentArea = 0;
                    DepthFirstSearch(matrix, i, j);

                    if (CurrentArea > bestArea)
                    {
                        bestArea = CurrentArea;
                    }
                }
            }
        }

        Console.WriteLine(bestArea);
    }
}
