namespace LabyrinthPaths
{
    using System;

    public struct Cell
    {
        // fields
        private int row;
        private int col;

        // constructors
        public Cell(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        // properties
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Row coordinates are negative.");
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Column coordinates are negative.");
                }

                this.col = value;
            }
        }
    }
}