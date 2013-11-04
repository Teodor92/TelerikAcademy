using System;
using System.IO;

public class MaxSumElements
{
    public static int MatrixSumFiner(int[,] matrix)
    {
        int bestSum = int.MinValue;
        for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
            {
                // 3x3 checker 
                // * * * - -
                // * * * - -
                // * * * - -
                int currentSum = 0;
                for (int newRow = rows; newRow < rows + 2; newRow++)
                {
                    for (int newCol = cols; newCol < cols + 2; newCol++)
                    {
                        currentSum = currentSum + matrix[newRow, newCol];
                    }
                }

                // best sum check
                if (bestSum <= currentSum)
                {
                    bestSum = currentSum;
                }
            }
        }

        return bestSum;
    }

    public static void Main()
    {
        StreamReader fileReader = new StreamReader(@"..\..\Ex.5\InOne.txt");
        StreamWriter fileWriter = new StreamWriter(@"..\..\Ex.5\OutResult.txt");
        int matrixWidthHeight = 0;
        int result = 0;
        using (fileReader)
        {
            string line = fileReader.ReadLine();
            matrixWidthHeight = int.Parse(line);

            int[,] matrix = new int[matrixWidthHeight, matrixWidthHeight];

            line = fileReader.ReadLine();
            int lineNumber = 0;
            while (line != null)
            {
                lineNumber++;
                string[] matrixNums = line.Split(' ');
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[lineNumber - 1, i] = int.Parse(matrixNums[i]);
                }

                line = fileReader.ReadLine();
            }

            result = MatrixSumFiner(matrix);
        }

        using (fileWriter)
        {
            fileWriter.WriteLine(result);
        }
    }
}
