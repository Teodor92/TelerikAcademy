namespace _8.QuoteProblems
{
    using System;

    /// <summary>
    /// Declare two string variables and assign them with following value:
    /// The "use" of quotations causes difficulties.
    /// Do the above in two different ways: with and without using quoted strings.
    /// </summary>
    public class QuoteProblems
    {
        internal static void Main()
        {
            Console.WriteLine("The \"use\" of quotations causes difficulties.");
            Console.WriteLine(@"The ""use"" of quotations causes difficulties.");
        }
    }
}
