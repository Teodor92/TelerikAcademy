/* Extend the program to support also 
 * subtraction and multiplication of polynomials. */

using System;
using System.Collections.Generic;
using System.Text;

public class PolynomalMultiplication
{
    public static void PolyAddition(int[] firstPoly, int[] secondPoly)
    {
        List<int> finallPoly = new List<int>();

        if (firstPoly.Length >= secondPoly.Length)
        {
            for (int i = 0; i < firstPoly.Length; i++)
            {
                finallPoly.Add(firstPoly[i] + secondPoly[i]);
            }
        }
        else
        {
            for (int i = 0; i < secondPoly.Length; i++)
            {
                finallPoly.Add(firstPoly[i] + secondPoly[i]);
            }
        }

        StringBuilder finalPolyStr = new StringBuilder();
        if (finallPoly[0] != 0)
        {
            finalPolyStr.AppendFormat("{0} ", finallPoly[0]);
        }

        for (int i = 1; i < finallPoly.Count; i++)
        {
            if (finallPoly[i] != 0 && finallPoly[i] > 0)
            {
                finalPolyStr.AppendFormat("+ {0}^x{1} ", finallPoly[i], i);
            }

            if (finallPoly[i] < 0)
            {
                finalPolyStr.AppendFormat("{0}^x{1} ", finallPoly[i], i);
            }
        }

        Console.WriteLine(finalPolyStr.ToString());
    }

    public static void PolySubtraction(int[] firstPoly, int[] secondPoly)
    {
        List<int> finallPoly = new List<int>();

        if (firstPoly.Length >= secondPoly.Length)
        {
            for (int i = 0; i < firstPoly.Length; i++)
            {
                finallPoly.Add(firstPoly[i] - secondPoly[i]);
            }
        }
        else
        {
            for (int i = 0; i < secondPoly.Length; i++)
            {
                finallPoly.Add(firstPoly[i] - secondPoly[i]);
            }
        }

        StringBuilder finalPolyStr = new StringBuilder();
        if (finallPoly[0] != 0)
        {
            finalPolyStr.AppendFormat("{0} ", finallPoly[0]);
        }

        for (int i = 1; i < finallPoly.Count; i++)
        {
            if (finallPoly[i] != 0 && finallPoly[i] > 0)
            {
                finalPolyStr.AppendFormat("+ {0}^x{1} ", finallPoly[i], i);
            }

            if (finallPoly[i] < 0)
            {
                finalPolyStr.AppendFormat("{0}^x{1} ", finallPoly[i], i);
            }
        }

        Console.WriteLine(finalPolyStr.ToString());
    }

    public static void PolyMultiplication(int[] firstPoly, int[] secondPoly)
    {
        int[] finalPoly = new int[firstPoly.Length + secondPoly.Length];
        int startingCell = 0;
        for (int i = 0; i < firstPoly.Length; i++)
        {
            startingCell = i;
            for (int j = 0; j < secondPoly.Length; j++)
            {
                finalPoly[startingCell] = finalPoly[startingCell] + (secondPoly[j] * firstPoly[i]);
                startingCell++;
            }
        }

        StringBuilder finalPolyStr = new StringBuilder();
        if (finalPoly[0] != 0)
        {
            finalPolyStr.AppendFormat("{0} ", finalPoly[0]);
        }

        for (int i = 1; i < finalPoly.Length; i++)
        {
            if (finalPoly[i] != 0 && finalPoly[i] > 0)
            {
                finalPolyStr.AppendFormat("+ {0}^x{1} ", finalPoly[i], i);
            }

            if (finalPoly[i] < 0)
            {
                finalPolyStr.AppendFormat("{0}^x{1} ", finalPoly[i], i);
            }
        }

        Console.WriteLine(finalPolyStr.ToString());
    }

    public static void Main()
    {
        int[] firstPoly = { 3, -1, 4, -3, -2 };
        int[] secondPoly = { 8, 1, 3, 0, 0 };

        Console.WriteLine("Addition");
        PolyAddition(firstPoly, secondPoly);

        Console.WriteLine("Substracion");
        PolySubtraction(firstPoly, secondPoly);

        Console.WriteLine("Multiplication");
        PolyMultiplication(firstPoly, secondPoly);
    }
}
