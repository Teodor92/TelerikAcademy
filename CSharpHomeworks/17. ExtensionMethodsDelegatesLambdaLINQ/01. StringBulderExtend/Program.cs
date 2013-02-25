using System;
using System.Text;

public class Program
{
    static void Main()
    {
        StringBuilder testing = new StringBuilder();
        testing.AppendLine("SOME words");
        Console.WriteLine(testing.SubString(5, 5).ToString());
    }
}
