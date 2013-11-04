using System;
using System.Collections.Generic;
using System.Linq;

class Stars3D
{
    static int width, height, depth;
    static int numberOfStars;
    static Dictionary<char, int> starTypes = new Dictionary<char, int>();

    static char[, ,] ReadInput()
    {
        string[] dimentions = Console.ReadLine().Split();
        width = int.Parse(dimentions[0]);
        height = int.Parse(dimentions[1]);
        depth = int.Parse(dimentions[2]);
        char[, ,] cube = new char[width, height, depth];
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

    static void StarFinder(char[, ,] cube, int w, int h, int d)
    {
        bool isStar = true;
        char curChar = cube[w, h, d];

        isStar = (cube[w + 1, h, d] == curChar) && (cube[w - 1, h, d] == curChar) &&
            (cube[w, h + 1, d] == curChar) && (cube[w, h - 1, d] == curChar) &&
            (cube[w, h, d + 1] == curChar) && (cube[w, h, d - 1] == curChar);

        if (isStar)
        {
            numberOfStars++;
            if (starTypes.ContainsKey(curChar))
            {
                starTypes[curChar]++;
            }
            else
            {
                starTypes.Add(curChar, 1);
            }
        }
    }

    static void Main()
    {
        char[, ,] cube = ReadInput();

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
        var sortedStars = starTypes.OrderBy(x => x.Key);
        foreach (var star in sortedStars)
        {
            Console.WriteLine("{0} {1}", star.Key, star.Value);
        }
    }
}
