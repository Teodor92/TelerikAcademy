namespace _06.QuadraticEquationSolver
{
    using System;

    /// <summary>
    /// Write a program that reads the coefficients 
    /// a, b and c of a quadratic equation ax2+bx+c=0
    /// and solves it (prints its real roots).
    /// </summary>
    public class QuadraticEquationSolver
    {
        internal static void Main()
        {
            double a = int.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());
            double c = int.Parse(Console.ReadLine());
            double discriminant = (b * b) - (4 * a * c);

            if (a == 0)
            {
                Console.WriteLine("There is one real root - x1: {0}", -c / b);
            }
            else if (discriminant > 0)
            {
                double valueXOne = (-b + Math.Sqrt(discriminant)) / 2 * a;
                double valueXTwo = (-b - Math.Sqrt(discriminant)) / 2 * a;
                Console.WriteLine("There are two real roots - x1: {0} and x2: {1}", valueXOne, valueXTwo);
            }
            else if (discriminant == 0)
            {
                double valueXOne = -(b / 2 * a);
                Console.WriteLine("There is one real root - x1: {0}", valueXOne);
            }
            else
            {
                Console.WriteLine("There are no real roots");
            }
        }
    }
}