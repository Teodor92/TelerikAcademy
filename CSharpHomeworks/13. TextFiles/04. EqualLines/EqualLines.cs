/* Write a program that compares two text files line 
 * by line and prints the number of lines that are 
 * the same and the number of lines that are different. 
 * Assume the files have equal number of lines.
 */

using System;
using System.IO;

public class EqualLines
{
    public static void Main()
    {
        StreamReader readerOne = new StreamReader(@"..\..\Ex.4\InOne.txt");
        StreamReader readerTwo = new StreamReader(@"..\..\Ex.4\InTwo.txt");

        string lineFirstFile = readerOne.ReadLine();
        string lineSecondFile = readerTwo.ReadLine();
        int line = 0;
        while (lineFirstFile != null)
        {
            line++;

            if (lineFirstFile == lineSecondFile)
            {
                Console.WriteLine("Lines {0} are equal", line);
            }
            else
            {
                Console.WriteLine("Lines {0} are NOT equal", line);
            }

            lineFirstFile = readerOne.ReadLine();
            lineSecondFile = readerTwo.ReadLine();
        }

        readerOne.Close();
        readerTwo.Close();
    }
}
