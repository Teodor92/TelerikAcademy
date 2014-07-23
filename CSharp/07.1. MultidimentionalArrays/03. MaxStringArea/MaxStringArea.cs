namespace _03.MaxStringArea
{
    using System;

    public class StringMatrix
    {
        public static void Main()
        {
            // direction arrays
            // TODO Merge in one array
            int[] dirRow = { 1, 0, 1, -1 };
            int[] dirCol = { 0, 1, 1, 1 };

            // The string array
            string[,] matrixStrings =
            {
                { "ha", "asd", "s", "s", "s", "ha" },
                { "g", "ha", "s", "s", "s", "ha" },
                { "s", "g", "s", "s", "s", "ha" },
                { "s", "s", "s", "s", "s", "ha" },
                { "s", "s", "s", "s", "ha", "ha" },
                { "s", "s", "s", "s", "ha", "ha" },
                { "s", "s", "s", "s", "ha", "ha" },
                { "s", "s", "s", "s", "ha", "ha" },
            };

            int bestLen = 0;
            string bestString = string.Empty;
            int numRows = matrixStrings.GetLength(0);
            int numCols = matrixStrings.GetLength(1);
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    string currentStr = matrixStrings[row, col];
                    int currentLen = 1;

                    // direction change
                    for (int direction = 0; direction < 4; direction++)
                    {
                        int currentRow = row;
                        int currentCol = col;
                        while (true)
                        {
                            currentCol += dirCol[direction];
                            currentRow += dirRow[direction];

                            // Out of array na different string checks
                            // TODO - make a seperate method
                            if (currentCol < 0 ||
                                currentCol >= numCols ||
                                currentRow < 0 ||
                                currentRow >= numRows ||
                                currentStr != matrixStrings[currentRow, currentCol])
                            {
                                break;
                            }

                            currentLen++;

                            // best len check
                            if (currentLen >= bestLen)
                            {
                                bestLen = currentLen;
                                bestString = currentStr;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("The longest sequence of strings in the array is - \"{0}\", with length - {1}", bestString, bestLen);
        }
    }
}
