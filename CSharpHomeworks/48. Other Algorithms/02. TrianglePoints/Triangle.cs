namespace TrianglePoints
{

    public class Triangle
    {
        public Triangle(Point a, Point b, Point c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public Point A { get; set; }

        public Point B { get; set; }

        public Point C { get; set; }

        public bool CheckIfPointIsInTriangle(Point x)
        {
            double alpha =
                          ((this.B.PointY - this.C.PointY) * (x.PointX - this.C.PointX) +
                          (this.C.PointX - this.B.PointX) * (x.PointY - this.C.PointY)) /
                          ((this.B.PointY - this.C.PointY) * (this.A.PointX - this.C.PointX) +
                          (this.C.PointX - this.B.PointX) * (this.A.PointY - this.C.PointY));

            double beta =
                         ((this.C.PointY - this.A.PointY) * (x.PointX - this.C.PointX) +
                         (this.A.PointX - this.C.PointX) * (x.PointY - this.C.PointY)) /
                         ((this.B.PointY - this.C.PointY) * (this.A.PointX - this.C.PointX) +
                         (this.C.PointX - this.B.PointX) * (this.A.PointY - this.C.PointY));

            double gamma = 1.0 - alpha - beta;

            if (alpha > 0 && beta > 0 && gamma > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}