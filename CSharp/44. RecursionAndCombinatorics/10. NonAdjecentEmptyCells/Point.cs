namespace NonAdjacentEmptyCells
{
    public struct Point
    {
        public Point(int x, int y)
            : this()
        {
            this.CoordX = x;
            this.CoordY = y;
        }

        public int CoordX { get; set; }

        public int CoordY { get; set; }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", this.CoordX, this.CoordY);
        }
    }
}
