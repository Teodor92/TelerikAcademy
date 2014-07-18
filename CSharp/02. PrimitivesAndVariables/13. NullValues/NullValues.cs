namespace _13.NullValues
{
    using System;

    /// <summary>
    /// Create a program that assigns null values to an integer and to double variables.
    /// Try to print them on the console, try to add some values or the null literal to them and see the result.
    /// </summary>
    public class NullValues
    {
        internal static void Main()
        {
            int? nullVauleOne = null;
            double? nullValueTwo = null;
            Console.WriteLine("First varibale {0} and second varibale {1}", nullVauleOne, nullValueTwo);
            Console.WriteLine(nullVauleOne + nullValueTwo);
            Console.WriteLine(nullVauleOne + 12);
            nullVauleOne = 5;
            Console.WriteLine(nullVauleOne.GetValueOrDefault());
        }
    }
}
