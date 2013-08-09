namespace LabyrinthPathExistis
{
    using System;

    public class Program
    {
        private static bool pathIsFound = false;

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
                || labyrinth[currentPoint.CoordX, currentPoint.CoordY] == "*"
                || pathIsFound)
            {
                return false;
            }

            return true;
        }

        public static void FindPaths(string[,] labyrinth, Point startingPoint)
        {
            if (labyrinth[startingPoint.CoordX, startingPoint.CoordY] == "EXIT")
            {
                pathIsFound = true;
                return;
            }

            labyrinth[startingPoint.CoordX, startingPoint.CoordY] = "X";

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                Point newPoint = new Point(startingPoint.CoordX + directions[i, 0], startingPoint.CoordY + directions[i, 1]);

                if (IsPassable(labyrinth, newPoint))
                {
                    FindPaths(labyrinth, newPoint);
                }
            }

            labyrinth[startingPoint.CoordX, startingPoint.CoordY] = " ";
        }

        public static Point FindStartingPoint(string[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == "START")
                    {
                        return new Point(i, j);
                    }
                }
            }

            throw new ArgumentException("Labyrinth has no start");
        }

        public static void Main()
        {
            // testing with a empty 100x100 matrix
            string[,] labyrinth = new string[100, 100];

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    labyrinth[i, j] = " ";
                }
            }

            labyrinth[0, 0] = "START";
            labyrinth[99, 99] = "EXIT";

            Point startingPoint = FindStartingPoint(labyrinth);

            FindPaths(labyrinth, startingPoint);

            Console.WriteLine(pathIsFound);
        }
    }
}
