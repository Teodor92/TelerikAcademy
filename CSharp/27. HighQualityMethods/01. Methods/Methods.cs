namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should ne positeve!");
            }

            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
            return area;
        }

        public static string ConvertNumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Number was invalid!");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("There are no input argumnets!");
            }

            int localMax = int.MinValue;

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > localMax)
                {
                    localMax = elements[i];
                }
            }

            return localMax;
        }

        public static void PrintNumberWithPrecisionTwo(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberMultipliedByHundredPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintWithAlignmentEight(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static bool CheckIfItsHorisontal(double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);

            return isHorizontal;
        }

        public static bool CheckIfItsVertical(double x1, double x2)
        {
            bool isHorizontal = (x1 == x2);

            return isHorizontal;
        }

        public static double CalcTwoDemetionalDistance(
            double x1,
            double y1,
            double x2,
            double y2)
        {
            if (y1 == y2 && x1 == x2)
            {
                throw new ArgumentException("There is no line!");
            }

            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertNumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumberWithPrecisionTwo(1.3);
            PrintNumberMultipliedByHundredPercent(0.75);
            PrintWithAlignmentEight(2.30);

            Console.WriteLine(CalcTwoDemetionalDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + CheckIfItsVertical(2, 2));
            Console.WriteLine("Vertical? " + CheckIfItsVertical(3, 3));

            Student peter = new Student("Peter", "Ivanov", "17.03.1992");

            Student stella = new Student("Stella", "Markova", "03.11.1993");

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
