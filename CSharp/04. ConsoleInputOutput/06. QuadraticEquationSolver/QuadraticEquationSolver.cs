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
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            if (a == 0)
            {
                double result = -(c / b);
                Console.WriteLine("There is one root - x1 = {0}", result);
            }

            double discriminant = (b * b) - (4 * a * c);
            if (discriminant > 0)
            {
                double valueOfxOne = (-b + Math.Sqrt(discriminant)) / 2 * a;
                double valueOfxTwo = (-b - Math.Sqrt(discriminant)) / 2 * a;
                Console.WriteLine("There are two real roots - x1: {0} and x2: {1}", valueOfxOne, valueOfxTwo);
            }
            else if (discriminant == 0)
            {
                double valueOfxOne = -(b / 2 * a);
                Console.WriteLine("There is one real root - x1: {0}", valueOfxOne);
            }
            else
            {
                Console.WriteLine("There are no real roots");
            }
        }
    }
}
