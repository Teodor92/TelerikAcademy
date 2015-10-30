namespace _09.TradeMark
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
    /// Use Windows Character Map to find the Unicode code of the © symbol. 
    /// Note: the © symbol may be displayed incorrectly.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            // Reset console encoding and current culture in order to prevent IO problems
            Console.OutputEncoding = Encoding.Unicode;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.OutputEncoding = Encoding.Unicode;
            int copyRignt = 169;
            byte spaceing = 2;
            for (int rows = 0; rows < 3; rows++)
            {
                for (int spaceCounter = 0; spaceCounter < spaceing; spaceCounter++)
                {
                    Console.Write(" ");
                }

                for (int cols = 0; cols <= rows; cols++)
                {
                    Console.Write((char)copyRignt);
                }

                for (int cols = 0; cols <= rows - 1; cols++)
                {
                    Console.Write((char)copyRignt);
                }

                spaceing--;
                Console.WriteLine();
            }
        }
    }
}