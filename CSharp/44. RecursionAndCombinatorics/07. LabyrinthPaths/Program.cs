namespace LabyrinthPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public static void FindPaths(string[,] labyrinth, Point startingPoint, string currentPath)
        {
            if (labyrinth[startingPoint.CoordX, startingPoint.CoordY] == "EXIT")
            {
                Console.WriteLine(currentPath);
                return;
            }

            labyrinth[startingPoint.CoordX, startingPoint.CoordY] = "X";

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                Point newPoint = new Point(startingPoint.CoordX + directions[i, 0], startingPoint.CoordY + directions[i, 1]);

                if (IsPassable(labyrinth, newPoint))
                {
                    currentPath += newPoint.ToString();

                    FindPaths(labyrinth, newPoint, currentPath);
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
            string[,] labyrinth = 
            {
                { "START", " ", " ", "*", " ", " ", " " },
                { "*", "*", " ", "*", " ", "*", " " },
                { " ", " ", " ", " ", " ", " ", " " },
                { " ", "*", "*", "*", "*", "*", " " },
                { " ", " ", " ", " ", " ", " ", "EXIT" },
            };

            Point startingPoint = FindStartingPoint(labyrinth);

            FindPaths(labyrinth, startingPoint, string.Empty);
        }
    }
}
