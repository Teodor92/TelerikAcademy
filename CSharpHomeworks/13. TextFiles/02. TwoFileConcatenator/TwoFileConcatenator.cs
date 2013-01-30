using System;
using System.IO;

public class TwoFileConcatenator
{
    public static void Main()
    {
        StreamReader readerOne = new StreamReader(@"..\..\Ex.2\InOne.txt");
        StreamReader readerTwo = new StreamReader(@"..\..\Ex.2\InTwo.txt");
        StreamWriter writer = new StreamWriter(@"..\..\Ex.2\OutResult.txt");
        string inOne = string.Empty;
        using (readerOne)
        {
            inOne = readerOne.ReadToEnd();
        }

        using (readerTwo)
        {
            inOne = inOne + readerTwo.ReadToEnd();
        }

        using (writer)
        {
            writer.Write(inOne);
        }
    }
}
