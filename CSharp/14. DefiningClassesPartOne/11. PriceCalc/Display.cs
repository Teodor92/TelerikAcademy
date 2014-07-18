namespace _11.PriceCalc
{
    using System;
    using System.Text;

    public class Display
    {
        private int size;
        private int? numberOfColors;

        // constructor
        public Display(int size)
            : this(size, null)
        {
        }

        public Display(int size, int? numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        // properties
        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value >= 0)
                {
                    this.size = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                if (value >= 0 || value == null)
                {
                    this.numberOfColors = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        // methods
        public override string ToString()
        {
            var endText = new StringBuilder();
            endText.AppendLine("---------Display --------");
            endText.AppendLine(this.size.ToString());
            endText.AppendLine(this.numberOfColors.ToString());
            return endText.ToString();
        }
    }
}