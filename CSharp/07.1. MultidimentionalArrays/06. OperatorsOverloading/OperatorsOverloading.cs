namespace _06.OperatorsOverloading
{
    using System;

    public class OperatorsOverloading
    {
        public static void Main()
        {
            Matrix firstMatrix = new Matrix(3, 3);
            Matrix secondMatrix = new Matrix(3, 3);
            Random randomGen = new Random();
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Cols; j++)
                {
                    firstMatrix[i, j] = randomGen.Next(10);
                    secondMatrix[i, j] = randomGen.Next(10);
                }
            }

            Console.WriteLine("First matrix:");
            Console.WriteLine(firstMatrix);

            Console.WriteLine("Second Matrix:");
            Console.WriteLine(secondMatrix);

            Console.WriteLine("Matrices sum:");
            Console.WriteLine(firstMatrix + secondMatrix);

            Console.WriteLine("Matrices substraction");
            Console.WriteLine(firstMatrix - secondMatrix);

            Console.WriteLine("Matrices multiplication");
            Console.WriteLine(firstMatrix * secondMatrix);
        }
    }
}