namespace JustMines
{
    using System;
    using System.Linq;

    internal class Player
    {
        private string name;
        private int points;

        public Player()
        {
        }

        public Player(string name, int point)
        {
            this.name = name;
            this.points = point;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int PlayerPoints
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}
