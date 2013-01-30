/* Write a program that compares 
 * two char arrays lexicographically (letter by letter).
 */

using System;

public class CharCompare
{
    public static void Main()
    {
        char[] firstArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'r' };
        char[] secondArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
        bool areLexiEqual = true;

        // to do len check
        if (firstArray.Length == secondArray.Length)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    areLexiEqual = false;
                }
            }

            Console.WriteLine("The arrays are equal: {0} .", areLexiEqual);
        }
        else
        {
            areLexiEqual = false;
            Console.WriteLine("The arrays are equal: {0} .", areLexiEqual);
        }
    }
}
