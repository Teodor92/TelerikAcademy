using System;

public class Matrix<T> where T : IComparable
{
    public readonly int cols;
    public readonly int rows;
    private T[,] matrix;

    public Matrix(int cols, int rows)
    {
        this.cols = cols;
        this.rows = rows;
        matrix = new T[cols, rows];
    }

    public T this[int rowPos, int colPos]
    {
        get
        {
            return matrix[rowPos, colPos];
        }

        set
        {
            matrix[rowPos, colPos] = value;
        }
    }

    public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.rows, firstMatrix.cols);
        if (firstMatrix.cols == secondMatrix.cols && firstMatrix.rows == secondMatrix.rows)
        {
            
            for (int i = 0; i < firstMatrix.rows; i++)
            {
                for (int j = 0; j < firstMatrix.rows; j++)
                {
                    dynamic tempValueOne = firstMatrix[i, j];
                    dynamic tempValueTwo = secondMatrix[i, j];
                    finalMatrix[i, j] = tempValueOne + tempValueTwo;
                }
            }
        }
        else
        {
            throw new ArgumentException("Wrongs sizeses");
        }

        return finalMatrix;
    }

    public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.rows, firstMatrix.cols);
        if (firstMatrix.cols == secondMatrix.cols && firstMatrix.rows == secondMatrix.rows)
        {
            for (int i = 0; i < firstMatrix.rows; i++)
            {
                for (int j = 0; j < firstMatrix.rows; j++)
                {
                    dynamic tempValueOne = firstMatrix[i, j];
                    dynamic tempValueTwo = secondMatrix[i, j];
                    finalMatrix[i, j] = tempValueOne - tempValueTwo;
                }
            }
        }
        else
        {
            throw new ArgumentException("Wrongs sizeses");
        }

        return finalMatrix;
    }

    public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.rows, firstMatrix.cols);
        for (int i = 0; i < finalMatrix.rows; i++)
        {
            for (int j = 0; j < finalMatrix.cols; j++)
            {
                for (int multiCol = 0; multiCol < firstMatrix.cols; multiCol++)
                {
                    for (int k = 0; k < firstMatrix.cols; k++)
                    {
                        dynamic tempValueOne = firstMatrix[i, j];
                        dynamic tempValueTwo = secondMatrix[i, j];
                        finalMatrix[i, j] += tempValueOne * tempValueTwo;
                    }
                }
            }
        }

        return finalMatrix;
    }

    public static bool operator true(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    { 
        // fuck yea!
        return false;
    }
}
