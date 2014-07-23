namespace _02.TrianglePoints
{
    public struct Point
    {
        public Point(double pointX, double pointY)
            : this()
        {
            this.PointX = pointX;
            this.PointY = pointY;
        }

        public double PointX { get; set; }

        public double PointY { get; set; }
    }
}