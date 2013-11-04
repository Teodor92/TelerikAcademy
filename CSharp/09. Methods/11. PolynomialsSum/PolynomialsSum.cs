/* Write a method that adds two polynomials. 
 * Represent them as arrays of their coefficients 
 * as in the example below:
 * x2 + 5 = 1x2 + 0x + 5  
 */

using System;
using System.Collections.Generic;
using System.Text;

public class PolynomialsSum
{
    public static void PollyAddition(int[] firstPoly, int[] secondPoly)
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

    public static void Main()
    {
        int[] firstPoly = { 5, 0, 1 };
        int[] secondPoly = { 10, -15, 9 };

        PollyAddition(firstPoly, secondPoly);
    }
}
