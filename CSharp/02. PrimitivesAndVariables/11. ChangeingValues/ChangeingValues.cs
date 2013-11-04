// Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.

using System;

class ChangeingValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        int c;
        c = a;
        a = b;
        b = c;
        Console.WriteLine("The value of \" a \" is {0} and the value of \" b \" is {1}", a, b);
    }
}
