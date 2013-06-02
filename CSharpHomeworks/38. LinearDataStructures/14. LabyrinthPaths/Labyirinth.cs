namespace LabyrinthPaths
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Labyirinth
    {
        // TODO: Make labyrinth dynamicly generated
        private readonly string[,] labyrinth = 
        {
            { "0", "0", "0", "X", "0", "X" },
            { "0", "X", "0", "X", "0", "X" },
            { "0", "*", "X", "0", "X", "0" },
            { "0", "X", "0", "0", "0", "0" },
            { "0", "0", "0", "X", "X", "0" },
            { "0", "0", "0", "X", "0", "X" }
        };

        private readonly int[,] directions = 
        {
            { 0, 1 }, // right
            { 1, 0 }, // down
            { 0, -1 }, // left
            { -1, 0 } // up
        };

        // constructors

        public Labyirinth()
        {
        }

        public Labyirinth(string[,] customLabyrinth)
        {
            this.labyrinth = customLabyrinth;
        }

        // methods
        public bool CheckIfPassable(int row, int col)
        {
            bool isPassable =
                row >= 0 && row < this.labyrinth.GetLength(0) &&
                col >= 0 && col < this.labyrinth.GetLength(1)
                && this.labyrinth[row, col] == "0";
            return isPassable;
        }

        /*
         * A DFS search - not working in this case but still 
         * it was interesting to implement so I leave it here 
         * for anyone is interested to see how it works :)
         */
        public void DepthFirstSearch(int row, int col, int currentCount = 0)
        {
            currentCount++;

            for (int i = 0; i < this.directions.GetLength(0); i++)
            {
                int newRow = row + this.directions[i, 0];
                int newCol = col + this.directions[i, 1];

                if (CheckIfPassable(newRow, newCol))
                {
                    this.labyrinth[newRow, newCol] = currentCount.ToString();
                    this.DepthFirstSearch(newRow, newCol, currentCount);
                }
            }
        }

        public void BreathFirstSearch(Cell startingPoint)
        {
            Queue<Tuple<Cell, int>> queue = new Queue<Tuple<Cell, int>>();
            queue.Enqueue(new Tuple<Cell, int>(startingPoint, 1));
            while (queue.Count > 0)
            {
                Tuple<Cell, int> currentElement = queue.Dequeue();

                for (int i = 0; i < this.directions.GetLength(0); i++)
                {
                    int newRow = currentElement.Item1.Row + this.directions[i, 0];
                    int newCol = currentElement.Item1.Col + this.directions[i, 1];

                    if (CheckIfPassable(newRow, newCol))
                    {
                        Cell child = new Cell();
                        child.Row = newRow;
                        child.Col = newCol;

                        this.labyrinth[child.Row, child.Col] = currentElement.Item2.ToString();
                        queue.Enqueue(new Tuple<Cell, int>(child, currentElement.Item2 + 1));
                    }
                }
            }
        }

        public Cell GetStartingPoint()
        {
            int rows = this.labyrinth.GetLength(0);
            int cols = this.labyrinth.GetLength(1);
            Cell startingPoint = new Cell();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (this.labyrinth[row, col] == "*")
                    {
                        startingPoint.Row = row;
                        startingPoint.Col = col;
                        return startingPoint;
                    }
                }
            }

            return startingPoint;
        }

        public void MapUnreachableCells()
        {
            int rows = this.labyrinth.GetLength(0);
            int cols = this.labyrinth.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (this.labyrinth[row, col] == "0")
                    {
                        this.labyrinth[row, col] = "u";
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            int rows = this.labyrinth.GetLength(0);
            int cols = this.labyrinth.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    output.AppendFormat("|{0,4}|", this.labyrinth[row, col]);
                }

                output.AppendLine();
            }

            return output.ToString();
        }
    }
}
