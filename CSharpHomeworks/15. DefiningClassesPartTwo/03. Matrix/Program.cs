using System;

class Program
{
    static void Main()
    {
        Matrix<int> matrixTesting = new Matrix<int>(20,20);
        Matrix<int> matrixTestingTwo = new Matrix<int>(10, 10);
        Console.WriteLine(matrixTesting.cols);

        matrixTesting[10, 10] = 200;
        matrixTesting[9, 9] = 3;
        Console.WriteLine(matrixTesting * matrixTestingTwo);
    }
}
