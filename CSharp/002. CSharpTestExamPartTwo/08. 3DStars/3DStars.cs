namespace _08._3DStars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Stars3D
    {
        private static readonly Dictionary<char, int> StarTypes = new Dictionary<char, int>();

        private static int width;
        private static int height;
        private static int depth;
        private static int numberOfStars;

        internal static void Main()
        {
            char[,,] cube = ReadInput();

            for (int w = 1; w < width - 1; w++)
            {
                for (int h = 1; h < height - 1; h++)
                {
                    for (int d = 1; d < depth - 1; d++)
                    {
                        StarFinder(cube, w, h, d);
                    }
                }
            }

            Console.WriteLine(numberOfStars);
            var sortedStars = StarTypes.OrderBy(x => x.Key);
            foreach (var star in sortedStars)
            {
                Console.WriteLine("{0} {1}", star.Key, star.Value);
            }
        }

        private static char[,,] ReadInput()
        {
            string[] dimentions = Console.ReadLine().Split();
            width = int.Parse(dimentions[0]);
            height = int.Parse(dimentions[1]);
            depth = int.Parse(dimentions[2]);
            var cube = new char[width, height, depth];
            for (int h = 0; h < height; h++)
            {
                string[] line = Console.ReadLine().Split();
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = line[d][w];
                    }
                }
            }

            return cube;
        }

        private static void StarFinder(char[,,] cube, int w, int h, int d)
        {
            bool isStar = true;
            char curChar = cube[w, h, d];

            isStar = (cube[w + 1, h, d] == curChar) && (cube[w - 1, h, d] == curChar) &&
                     (cube[w, h + 1, d] == curChar) && (cube[w, h - 1, d] == curChar) &&
                     (cube[w, h, d + 1] == curChar) && (cube[w, h, d - 1] == curChar);

            if (isStar)
            {
                numberOfStars++;
                if (StarTypes.ContainsKey(curChar))
                {
                    StarTypes[curChar]++;
                }
                else
                {
                    StarTypes.Add(curChar, 1);
                }
            }
        }
    }
}
