using System;

class Slices3D
{
    static int width, height, depth, totalSum, numberOfSlices;

    static int[, ,] ReadInput()
    {
        string[] dimentions = Console.ReadLine().Split();
        width = int.Parse(dimentions[0]);
        height = int.Parse(dimentions[1]);
        depth = int.Parse(dimentions[2]);

        int[, ,] cube = new int[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            string[] splitedLine = line.Split('|');
            for (int d = 0; d < depth; d++)
            {
                string[] numbers = splitedLine[d].Split(
                new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    int parsedNum = int.Parse(numbers[w]);
                    cube[w, h, d] = parsedNum;
                    totalSum += parsedNum;
                }
            }
        }

        return cube;
    }

    static void widthSlice(int[, ,] cube)
    {
        long sliceSum = 0;

        for (int w = 0; w < width - 1; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    sliceSum += cube[w, h, d];
                }
            }

            if (sliceSum * 2 == totalSum)
            {
                numberOfSlices++;
            }
        }
    }

    static void heightSlice(int[, ,] cube)
    {
        long sliceSum = 0;

        for (int h = 0; h < height - 1; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int d = 0; d < depth; d++)
                {
                    sliceSum += cube[w, h, d];
                }
            }

            if (sliceSum * 2 == totalSum)
            {
                numberOfSlices++;
            }
        }
    }

    static void depthSlice(int[, ,] cube)
    {
        long sliceSum = 0;

        for (int d = 0; d < depth - 1; d++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    sliceSum += cube[w, h, d];
                }
            }

            if (sliceSum * 2 == totalSum)
            {
                numberOfSlices++;
            }
        }
    }

    static void Main()
    {
        int[, ,] cube = ReadInput();
        widthSlice(cube);
        heightSlice(cube);
        depthSlice(cube);
        Console.WriteLine(numberOfSlices);
    }
}
