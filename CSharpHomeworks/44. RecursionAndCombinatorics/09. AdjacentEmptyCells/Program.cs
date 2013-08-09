namespace AdjacentEmptyCells
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static int[,] directions = 
        {
          { 0, 1 }, // right
          { 1, 0 }, // down
          { 0, -1 }, // left
          { -1, 0 } // up
        };

        public static bool IsPassable(string[,] labyrinth, Point currentPoint)
        {
            int rows = labyrinth.GetLength(0);
            int cols = labyrinth.GetLength(1);

            if (currentPoint.CoordX < 0
                || currentPoint.CoordY < 0
                || currentPoint.CoordX >= rows
                || currentPoint.CoordY >= cols
                || labyrinth[currentPoint.CoordX, currentPoint.CoordY] == "X"
                || labyrinth[currentPoint.CoordX, currentPoint.CoordY] == "*")
            {
                return false;
            }

            return true;
        }

        public static void FindPaths(string[,] labyrinth, Point startingPoint)
        {
            Queue<Point> pointQueue = new Queue<Point>();
            pointQueue.Enqueue(startingPoint);

            while (pointQueue.Count > 0)
            {
                Point currentElement = pointQueue.Dequeue();
                labyrinth[currentElement.CoordX, currentElement.CoordY] = "X";

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    int newXcoord = currentElement.CoordX + directions[i, 0];
                    int newYcoord = currentElement.CoordY + directions[i, 1];

                    Point newPoint = new Point(newXcoord, newYcoord);

                    if (IsPassable(labyrinth, newPoint))
                    {
                        pointQueue.Enqueue(newPoint);
                    }
                }
            }
        }

        public static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void Main()
        {
            string[,] labyrinth = 
            {
                { " ", " ", " ", "*", " ", "*", " " },
                { "*", "*", " ", "*", " ", "*", " " },
                { " ", " ", " ", "*", " ", "*", " " },
                { " ", "*", "*", "*", "*", "*", " " },
                { " ", " ", " ", " ", " ", " ", " " },
            };

            FindPaths(labyrinth, new Point(0, 0));

            PrintMatrix(labyrinth);
        }
    }
}
