using System;
using System.Text;

public class Matrix<T> where T : IComparable
{
    public readonly int Cols;
    public readonly int Rows;
    private readonly T[,] matrix;

    public Matrix(int cols, int rows)
    {
        this.Cols = cols;
        this.Rows = rows;
        this.matrix = new T[cols, rows];
    }

    public T this[int rowPos, int colPos]
    {
        get
        {
            if (rowPos < 0 || colPos < 0 || rowPos >= this.Rows || colPos >= this.Cols)
            {
                throw new IndexOutOfRangeException("Out of the matrix!");
            }

            return this.matrix[rowPos, colPos];
        }

        set
        {
            if (rowPos < 0 || colPos < 0 || rowPos >= this.Rows || colPos >= this.Cols)
            {
                throw new IndexOutOfRangeException("Out of the matrix!");
            }

            this.matrix[rowPos, colPos] = value;
        }
    }

    public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);
        if (firstMatrix.Cols == secondMatrix.Cols && firstMatrix.Rows == secondMatrix.Rows)
        {
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Rows; j++)
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
        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);
        if (firstMatrix.Cols == secondMatrix.Cols && firstMatrix.Rows == secondMatrix.Rows)
        {
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Rows; j++)
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
        if (firstMatrix.Cols != secondMatrix.Rows)
        {
            throw new ArithmeticException("Wrong sizeses");
        }

        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);
        for (int i = 0; i < finalMatrix.Rows; i++)
        {
            for (int j = 0; j < finalMatrix.Cols; j++)
            {
                for (int multiCol = 0; multiCol < firstMatrix.Cols; multiCol++)
                {
                    for (int k = 0; k < firstMatrix.Cols; k++)
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

    public static bool operator true(Matrix<T> matrix)
    {
        if (matrix == null || matrix.Rows == 0 || matrix.Cols == 0)
        {
            return false;
        }

        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
            {
                if (!matrix[row, col].Equals(default(T)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        if (matrix == null || matrix.Rows == 0 || matrix.Cols == 0)
        {
            return true;
        }

        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
            {
                if (!matrix[row, col].Equals(default(T)))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder endString = new StringBuilder();
        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                endString.AppendFormat("{0,5}", this[i, j]);
            }

            endString.AppendLine();
        }

        return endString.ToString();
    }
}
