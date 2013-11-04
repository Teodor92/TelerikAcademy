/* Write a method that asks the user for his name and 
 * prints “Hello, <name>” (for example, “Hello, Peter!”). 
 * Write a program to test this method.
 */

using System;

public class Hello
{
    public static string NameGreeter(string name)
    {
        string greeting = "Hello, " + name + "!";
        return greeting;
    }

    public static void Main()
    {
        string name = Console.ReadLine();
        Console.WriteLine(NameGreeter(name));
    }
}
