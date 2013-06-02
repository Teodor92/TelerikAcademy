namespace LabyrinthPaths
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Labyirinth myLabyrinth = new Labyirinth();
            Cell startingPoint = myLabyrinth.GetStartingPoint();

            ////DepthFirstSearch(labyrinth, startingPoint.row, startingPoint.col);
            myLabyrinth.BreathFirstSearch(startingPoint);
            myLabyrinth.MapUnreachableCells();

            Console.WriteLine(myLabyrinth.ToString());
        }
    }
}
