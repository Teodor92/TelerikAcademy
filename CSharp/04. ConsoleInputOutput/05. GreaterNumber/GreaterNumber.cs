namespace _05.GreaterNumber
{
    using System;

    /// <summary>
    /// Write a program that gets two numbers from 
    /// the console and prints the greater of them. 
    /// Don’t use if statements.
    /// </summary>
    public class GreaterNumber
    {
        internal static void Main()
        {
            Console.WriteLine("Please enter the first number:");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the second number:");
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("The greater number is:");
            Console.WriteLine(Math.Max(firstNumber, secondNumber));
        }
    }
}
