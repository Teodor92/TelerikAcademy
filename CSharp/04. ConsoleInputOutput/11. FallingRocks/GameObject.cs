namespace _11.FallingRocks
{
    using System;

    public struct GameObject
    {
        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public int ObjectLength { get; set; }

        public string Content { get; set; }

        public ConsoleColor Color { get; set; }
    }
}
