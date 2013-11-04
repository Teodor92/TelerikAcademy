using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class ProblemFive
{
    static void Main()
    {
        //input
        int[,] matrix = new int[8, 16];
        for (int row = 0; row < 8; row++)
        {
            int input = int.Parse(Console.ReadLine());
            for (int col = 0; col < 16; col++)
            {
                matrix[row, col] = input % 2;
                input = input / 2;
            }
        }
        // main logic
        // bird finder
        int score = 0;
        int flightLen = 0;
        int birdNum = 0;
        int deadPigs = 0;
        for (int birdCol = 8; birdCol < 16; birdCol++)
        {
            for (int birdRow = 0; birdRow < 8; birdRow++)
            {

                if (matrix[birdRow, birdCol] == 1)
                {
                    int defCol = birdCol;
                    int defRow = birdRow;
                    int dirRow = -1;
                    int dirCol = -1;
                    bool isDead = false;
                    while (isDead == false)
                    {

                        if (birdRow == 0)
                        {
                            dirRow = 1;
                        }
                        birdRow = birdRow + dirRow;
                        birdCol = birdCol + dirCol;
                        if (birdRow > 7 || birdCol < 0)
                        {
                            isDead = true;
                            break;
                        }
                        if (birdCol < 8 && matrix[birdRow, birdCol] == 1)
                        {
                            deadPigs++;
                            // 0 0 0
                            // 1 0 0
                            // 0 0 0
                            if (birdCol + 1 != 8)
                            {
                                if (matrix[birdRow, birdCol + 1] == 1)
                                {
                                    deadPigs++;
                                    matrix[birdRow, birdCol + 1] = 0;
                                }
                            }
                            // 0 0 0
                            // 0 0 0
                            // 1 0 0
                            if (birdRow < 7 && birdCol + 1 != 8)
                            {
                                if (matrix[birdRow + 1, birdCol + 1] == 1)
                                {
                                    deadPigs++;
                                    matrix[birdRow + 1, birdCol + 1] = 0;
                                }

                            }
                            // 0 0 0
                            // 0 0 0
                            // 0 1 0
                            if (birdRow < 7)
                            {
                                if (matrix[birdRow + 1, birdCol] == 1)
                                {
                                    deadPigs++;
                                    matrix[birdRow + 1, birdCol] = 0;
                                }
                            }
                            // 1 0 0
                            // 0 0 0
                            // 0 0 0
                            if (birdRow > 0 && birdCol + 1 != 8)
                            {
                                if (matrix[birdRow - 1, birdCol + 1] == 1)
                                {
                                    deadPigs++;
                                    matrix[birdRow - 1, birdCol + 1] = 0;
                                }
                            }
                            // 0 1 0
                            // 0 0 0
                            // 0 0 0
                            if (birdRow > 0)
                            {
                                if (matrix[birdRow - 1, birdCol] == 1)
                                {
                                    deadPigs++;
                                    matrix[birdRow - 1, birdCol] = 0;
                                }
                            }
                            // 0 0 1
                            // 0 0 0
                            // 0 0 0
                            if (birdRow > 0 && birdCol > 0)
                            {
                                if (matrix[birdRow - 1, birdCol - 1] == 1)
                                {
                                    deadPigs++;
                                    matrix[birdRow - 1, birdCol - 1] = 0;
                                }

                            }
                            // 0 0 0
                            // 0 0 1
                            // 0 0 0
                            if (birdCol > 0)
                            {
                                if (matrix[birdRow, birdCol - 1] == 1)
                                {
                                    deadPigs++;
                                    matrix[birdRow, birdCol - 1] = 0;
                                }

                            }
                            // 0 0 0
                            // 0 0 0
                            // 0 0 1
                            if (birdCol > 0 && birdRow < 7)
                            {
                                if (matrix[birdRow + 1, birdCol - 1] == 1)
                                {
                                    deadPigs++;
                                    matrix[birdRow + 1, birdCol - 1] = 0;
                                }
                            }
                            isDead = true;
                            matrix[birdRow, birdCol] = 0;
                        }

                        flightLen++;
                    }
                    birdRow = defRow;
                    birdCol = defCol;
                }
                score = score + flightLen * deadPigs;
                flightLen = 0;
                deadPigs = 0;
            }
        }
        // alive checker
        bool areAlive = false;
        for (int birdRow = 0; birdRow < 8; birdRow++)
        {
            for (int birdCol = 0; birdCol < 8; birdCol++)
            {
                if (matrix[birdRow, birdCol] == 1)
                {
                    areAlive = true;
                    break;
                }
            }
        }
        //testing
        //for (int i = 0; i < matrix.GetLength(0); i++)
        //{
        //    for (int j = 0; j < matrix.GetLength(1); j++)
        //    {
        //        Console.Write("{0}", matrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}
        Console.Write("{0} ", score);
        if (areAlive)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine("Yes");
        }


    }
}