namespace Slices3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            long totalSum = 0;

            string[] rawNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int width = int.Parse(rawNumbers[0]);
            int height = int.Parse(rawNumbers[1]);
            int depth = int.Parse(rawNumbers[2]);

            int[, ,] cube = new int[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string[] rawLine = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                for (int d = 0; d < depth; d++)
                {
                    rawNumbers = rawLine[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int w = 0; w < width; w++)
                    {
                        int number = int.Parse(rawNumbers[w]);
                        cube[w, h, d] = number;
                        totalSum += number;
                    }
                }
            }

            int allSlices = 0;
            allSlices += FindHeightSubCubes(cube, totalSum);
            allSlices += FindWidthSubCubes(cube, totalSum);
            allSlices += FindDepthSubCubes(cube, totalSum);

            Console.WriteLine(allSlices);
        }

        private static int FindHeightSubCubes(int[, ,] cube, long totalSum)
        {
            long sliceSum = 0;
            int equalSlices = 0;

            for (int h = 0; h < cube.GetLength(1) - 1; h++)
            {
                for (int w = 0; w < cube.GetLength(0); w++)
                {
                    for (int d = 0; d < cube.GetLength(2); d++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }

                if (sliceSum * 2 == totalSum)
                {
                    equalSlices++;
                    return equalSlices;
                }
            }

            return equalSlices;
        }

        private static int FindWidthSubCubes(int[, ,] cube, long totalSum)
        {
            long sliceSum = 0;
            int equalSlices = 0;

            for (int w = 0; w < cube.GetLength(0) - 1; w++)
            {
                for (int h = 0; h < cube.GetLength(1); h++)
                {
                    for (int d = 0; d < cube.GetLength(2); d++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }

                if (sliceSum * 2 == totalSum)
                {
                    equalSlices++;
                    return equalSlices;
                }
            }

            return equalSlices;
        }

        private static int FindDepthSubCubes(int[, ,] cube, long totalSum)
        {
            long sliceSum = 0;
            int equalSlices = 0;

            for (int d = 0; d < cube.GetLength(2) - 1; d++)
            {
                for (int w = 0; w < cube.GetLength(0); w++)
                {
                    for (int h = 0; h < cube.GetLength(1); h++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }

                if (sliceSum * 2 == totalSum)
                {
                    equalSlices++;
                    return equalSlices;
                }
            }

            return equalSlices;
        }
    }
}
