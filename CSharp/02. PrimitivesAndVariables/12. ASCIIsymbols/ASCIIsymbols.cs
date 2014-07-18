namespace _12.ASCIIsymbols
{
    using System;
    using System.Text;

    /// <summary>
    /// Find online more information about ASCII (American Standard Code for Information Interchange) and write a 
    /// program that prints the entire ASCII table of characters on the console.
    /// </summary>
    public class AsciIsymbols
    {
        internal static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            for (int i = 0; i <= 255; i++)
            {
                var symbol = (char)i;
                Console.WriteLine("ASCII symbol {0} and its number {1}", symbol, i);
            }
        }
    }
}
