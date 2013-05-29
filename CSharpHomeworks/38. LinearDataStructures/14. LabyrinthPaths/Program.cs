namespace LabyrinthPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public struct Point
    {
        public int Row;
        public int Col;
    }

    public class Program
    {
        private static string[,] labyrinth = 
        {
            { "0", "0", "0", "X", "0", "X" },
            { "0", "X", "0", "X", "0", "X" },
            { "0", "*", "X", "0", "X", "0" },
            { "0", "X", "0", "0", "0", "0" },
            { "0", "0", "0", "X", "X", "0" },
            { "0", "0", "0", "X", "0", "X" }
        };

        private static int[,] directions = 
        {
            { 0, 1 }, // right
            { 1, 0 }, // down
            { 0, -1 }, // left
            { -1, 0 } // up
        };

        public static bool CheckIfPassable(string[,] labyrinth, int row, int col)
        {
            bool isPassable =
                row >= 0 && row < labyrinth.GetLength(0) &&
                col >= 0 && col < labyrinth.GetLength(1)
                && labyrinth[row, col] == "0";
            return isPassable;
        }

        ////public static void DepthFirstSearch(string[,] labyrinth, int row, int col, int currentCount = 0)
        ////{
        ////    currentCount++;

        ////    for (int i = 0; i < directions.GetLength(0); i++)
        ////    {
        ////        int newRow = row + directions[i, 0];
        ////        int newCol = col + directions[i, 1];

        ////        if (CheckIfPassable(labyrinth, newRow, newCol))
        ////        {
        ////            labyrinth[newRow, newCol] = currentCount.ToString();
        ////            DepthFirstSearch(labyrinth, newRow, newCol, currentCount);
        ////        }
        ////    }
        ////}

        public static void BreathFirstSearch(string[,] labyrinth, Point startingPoint)
        {
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(startingPoint);
            int currentCount = 1;
            while (queue.Count > 0)
            {
                Point currentPoint = queue.Dequeue();

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    int newRow = currentPoint.Row + directions[i, 0];
                    int newCol = currentPoint.Col + directions[i, 1];

                    if (CheckIfPassable(labyrinth, newRow, newCol))
                    {
                        Point child = new Point();
                        child.Row = newRow;
                        child.Col = newCol;
                        labyrinth[child.Row, child.Col] = currentCount.ToString();
                        queue.Enqueue(child);
                    }
                }

                currentCount++;
            }
        }

        public static Point GetStartingPoint(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int cols = labyrinth.GetLength(1);
            Point startingPoint = new Point();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        startingPoint.Row = row;
                        startingPoint.Col = col;
                        return startingPoint;
                    }
                }
            }

            return startingPoint;
        }

        public static void PrintLabyirinth(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int cols = labyrinth.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0,4}", labyrinth[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void Main()
        {
            Point startingPoint = GetStartingPoint(labyrinth);
            Console.WriteLine(startingPoint.Row);
            Console.WriteLine(startingPoint.Col);

            ////DepthFirstSearch(labyrinth, startingPoint.row, startingPoint.col);
            BreathFirstSearch(labyrinth, startingPoint);

            PrintLabyirinth(labyrinth);
        }
    }
}
