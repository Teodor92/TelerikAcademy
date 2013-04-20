using System;

public class BoolExtends
{
    public class BoolConverter
    {
        public void PrintBoolAsString(bool variable)
        {
            string stringOutput = variable.ToString();
            Console.WriteLine(stringOutput);
        }
    }

    // Note: filed is unused
    private const int MaxCount = 6;

    public static void Main()
    {
        BoolExtends.BoolConverter simpleConverter = new BoolExtends.BoolConverter();
        simpleConverter.PrintBoolAsString(true);
    }
}
