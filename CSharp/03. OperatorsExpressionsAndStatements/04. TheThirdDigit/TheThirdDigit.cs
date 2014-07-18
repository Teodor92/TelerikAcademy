namespace _04.TheThirdDigit
{
    using System;

    /// <summary>
    /// Write an expression that checks for given integer if its third 
    /// digit (right-to-left) is 7. E. g. 1732  true.
    /// </summary>
    public class TheThirdDigit
    {
        internal static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = number / 100;
            int thirdDigit = number % 10;
            Console.WriteLine(thirdDigit);
            if (thirdDigit == 7)
            {
                Console.WriteLine("The third digit is 7");
            }
            else
            {
                Console.WriteLine("The third digit is NOT 7");
            }
        }
    }
}
