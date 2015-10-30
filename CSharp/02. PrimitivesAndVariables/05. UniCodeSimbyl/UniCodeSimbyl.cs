namespace _05.UniCodeSimbyl
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Declare a character variable and assign it with the symbol that has Unicode 
    /// code 72. Hint: first use the Windows Calculator to find the hexadecimal representation of 72.
    /// </summary>
    public class UniCodeSimbyl
    {
        public static void Main()
        {
            // Reset console encoding and current culture in order to prevent IO problems
            Console.OutputEncoding = Encoding.Unicode;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            char symbol = '\u0048';
            Console.WriteLine(symbol);
        }
    }
}
