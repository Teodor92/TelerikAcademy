namespace _08.QuoteProblems
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Declare two string variables and assign them with following value:
    /// The "use" of quotations causes difficulties.
    /// Do the above in two different ways: with and without using quoted strings.
    /// </summary>
    public class QuoteProblems
    {
        public static void Main()
        {
            // Reset console encoding and current culture in order to prevent IO problems
            Console.OutputEncoding = Encoding.Unicode;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("The \"use\" of quotations causes difficulties.");
            Console.WriteLine(@"The ""use"" of quotations causes difficulties.");
        }
    }
}
