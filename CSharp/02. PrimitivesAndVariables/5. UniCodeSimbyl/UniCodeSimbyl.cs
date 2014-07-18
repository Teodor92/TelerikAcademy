namespace _5.UniCodeSimbyl
{
    using System;

    /// <summary>
    /// Declare a character variable and assign it with the symbol that has Unicode 
    /// code 72. Hint: first use the Windows Calculator to find the hexadecimal representation of 72.
    /// </summary>
    public class UniCodeSimbyl
    {
        internal static void Main(string[] args)
        {
            char symbol = '\u0048';
            Console.WriteLine(symbol);
        }
    }
}
