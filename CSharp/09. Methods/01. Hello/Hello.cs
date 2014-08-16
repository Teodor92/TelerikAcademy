namespace _01.Hello
{
    using System;

    /// <summary>
    /// Write a method that asks the user for his name and 
    /// prints “Hello, <name>” (for example, “Hello, Peter!”). 
    /// Write a program to test this method.
    /// </summary>
    public class Hello
    {
        public static string GetGreeting(string name)
        {
            string greeting = "Hello, " + name + "!";
            return greeting;
        }

        internal static void Main()
        {
            string name = Console.ReadLine();
            Console.WriteLine(GetGreeting(name));
        }
    }
}
