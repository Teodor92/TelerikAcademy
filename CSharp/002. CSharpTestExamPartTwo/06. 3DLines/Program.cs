using System;
using System.Collections.Generic;

class Program
{
    static int width, height, depth;
    //static int[] dirWidth =  { 1, 0, 0, 1, 1, 0, -1, -1, 0, 1, 1, -1  };
    //static int[] dirHeight = { 0, 1, 0, 0, 1, 1, 1, -1, 1, -1, 1, 1 };
    //static int[] dirDepth =  { 0, 0, 1, 1, 1, 1, 0, -1, -1, -1, -1, -1 };

    static int[] dirWidth = { 1, 0, 1, -1, 0, 0, 0, 1, -1, 1, 1, 1, 1 };
    static int[] dirHeight = { 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, -1, 1, -1 };
    static int[] dirDepth = { 0, 0, 1, 1, 1, 1, -1, 0, 0, 1, 1, -1, -1 };

    static int maxLength = 1;
    static int numOfMaxLines = 0;

    static char[, ,] ReadLine()
    {
        // read width, height, depth
        string dimentions = Console.ReadLine();
        string[] splitedDims = dimentions.Split();
        width = int.Parse(splitedDims[0]);
        height = int.Parse(splitedDims[1]);
        depth = int.Parse(splitedDims[2]);
        char[, ,] cube = new char[width, height, depth];

        // poplulate cube

        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            string[] spiltedLine = line.Split();

            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = spiltedLine[d][w];
                }
            }
        }

        return cube;
    }

    static bool isPassable(char[, ,] myCube, int w, int h, int d)
    {
        if (d >= 0 && w >= 0 && h >= 0 && w < width && h < height && d < depth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        // input
        char[, ,] cube = ReadLine();

        for (int w = 0; w < cube.GetLength(0); w++)
        {
            for (int h = 0; h < cube.GetLength(1); h++)
            {
                for (int d = 0; d < cube.GetLength(2); d++)
                {


                    char curChar = cube[w, h, d];

                    for (int i = 0; i < dirDepth.Length; i++)
                    {
                        int lineLen = 1;
                        int currentW = w;
                        int curentH = h;
                        int currentD = d;

                        while (true)
                        {

                            currentW += dirWidth[i];
                            curentH += dirHeight[i];
                            currentD += dirDepth[i];
                            if (!isPassable(cube, currentW, curentH, currentD))
                            {
                                break;
                            }

                            if (cube[currentW, curentH, currentD] == curChar)
                            {
                                lineLen++;
                            }
                            else
                            {
                                break;
                            }
                        }


                        if (lineLen == maxLength)
                        {
                            numOfMaxLines++;
                        }
                        else if (lineLen > maxLength)
                        {
                            maxLength = lineLen;
                            numOfMaxLines = 1;
                        }
                    }

                }
            }
        }

        Console.WriteLine("{0} {1}", maxLength, numOfMaxLines);
    }
}
