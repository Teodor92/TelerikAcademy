namespace CodeFragments
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Potato potato = new Potato();

            // ... 
            if (potato != null)
            {
                if (potato.HasBeenPeeled && potato.IsNotRotten)
                {
                    Cook(potato);
                }
            }

            // Second half

            int x = 0;
            int y = 0;
            int minX = 0;
            int maxX = 0;
            int minY = 0;
            int maxY = 0;
            bool shouldVisitCell = true;

            bool xIsInRange = (x >= minX && x <= maxX);
            bool yIsInRange = (minY >= y && maxY <= y);

            if (xIsInRange && yIsInRange && shouldVisitCell)
            {
               VisitCell();
            }

        }

        private static void VisitCell()
        {
            throw new NotImplementedException();
        }

        private static void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }


    }
}
