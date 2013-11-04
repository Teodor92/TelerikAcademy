using System;

public class Matrix
{
    public int Rows;
    public int Cols;
    private int[,] matrix;

    // constructor
    public Matrix(int newRows, int newCols)
    {
        matrix = new int[newRows, newRows];
        Rows = newRows;
        Cols = newCols;
    }

    public int this[int newRows, int newCols]
    {
        get
        {
            return matrix[newRows, newCols];
        }

        set
        {
            matrix[newRows, newCols] = value;
        }
    }

    public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix finalMatrix = new Matrix(firstMatrix.Rows, firstMatrix.Cols);
        for (int i = 0; i < firstMatrix.Rows; i++)
        {
            for (int j = 0; j < firstMatrix.Rows; j++)
            {
                finalMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
            }
        }

        return finalMatrix;
    }

    public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix finalMatrix = new Matrix(firstMatrix.Rows, firstMatrix.Cols);
        for (int i = 0; i < firstMatrix.Rows; i++)
        {
            for (int j = 0; j < firstMatrix.Rows; j++)
            {
                finalMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
            }
        }

        return finalMatrix;
    }

    public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix finalMatrix = new Matrix(firstMatrix.Rows, firstMatrix.Cols);
        for (int i = 0; i < finalMatrix.Rows; i++)
        {
            for (int j = 0; j < finalMatrix.Cols; j++)
            {
                for (int multiCol = 0; multiCol < firstMatrix.Cols; multiCol++)
                {
                    for (int k = 0; k < firstMatrix.Cols; k++)
                    {
                        finalMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
        }

        return finalMatrix;
    }

    public override string ToString()
    {
        string endString = string.Empty;
        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                endString = endString + this[i, j] + " ";
            }

            endString = endString + "\n";
        }

        return endString;
    }
}

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
