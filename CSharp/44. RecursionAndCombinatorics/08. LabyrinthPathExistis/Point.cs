namespace LabyrinthPathExistis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
