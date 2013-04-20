namespace FigureRotator
{
    using System;

    public class Figure
    {
        // fileds
        private double width;
        private double height;

        // constructors
        public Figure(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        // properties
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width can not be a negative number");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height can not be a negative number");
                }

                this.height = value;
            }
        }
    }
}
