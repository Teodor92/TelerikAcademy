namespace _05.Lines
{
    using System;

    public class Lines
    {
        internal static void Main()
        {
            var allNumbers = new byte[8, 8];
            int[] dirRow = { 1, 0 };
            int[] dirCol = { 0, 1 };

            // input
            for (int row = 0; row < allNumbers.GetLength(0); row++)
            {
                byte number = byte.Parse(Console.ReadLine());
                for (int col = allNumbers.GetLength(1) - 1; col > -1; col--)
                {
                    if (number % 2 != 0)
                    {
                        allNumbers[row, col] = 1;
                    }

                    number = (byte)(number / 2);
                }
            }

            // helpers
            var length = 1;
            var bestLength = 0;
            var bestAmountOfLines = 0;
            var numRows = allNumbers.GetLength(0);
            var numCols = allNumbers.GetLength(1);

            // main logic
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (allNumbers[row, col] == 1)
                    {
                        byte currentByte = allNumbers[row, col];
                    }
                    else
                    {
                        byte currentByte = 0;
                    }

                    // direction change
                    for (int direction = 0; direction < 2; direction++)
                    {
                        int currentRow = row;
                        int currentCol = col;
                        int currentLen = 1;
                        while (true)
                        {
                            currentCol += dirCol[direction];
                            currentRow += dirRow[direction];

                            // out of bounds of the array
                            if (currentCol < 0 ||
                                currentCol >= numCols ||
                                currentRow < 0 ||
                                currentRow >= numRows
                                || allNumbers[currentRow, currentCol] == 0)
                            {
                                break;
                            }

                            currentLen++;

                            // best string check
                            if (currentLen == bestLength)
                            {
                                bestAmountOfLines++;
                            }
                            else if (currentLen > bestLength)
                            {
                                bestLength = currentLen;
                                bestAmountOfLines = 1;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(bestLength);
            Console.WriteLine(bestAmountOfLines);
        }
    }
}
