/* Write a program that reads from the console a 
 * string of maximum 20 characters. If the length of 
 * the string is less than 20, the rest of the 
 * characters should be filled with '*'. 
 * Print the result string into the console.
 */

using System;

public class StringDotFiller
{
    public static void Main()
    {
        string input = Console.ReadLine();
        if (input.Length <= 20)
        {
            Console.WriteLine(input + new string('*', 20 - input.Length));
        }
    }
}
