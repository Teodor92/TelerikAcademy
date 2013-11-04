/* Write a program that reads from the console a sequence of N 
 * integer numbers and returns the minimal and maximal of them.
 */

using System;

class MinimalMaximal
{
    static void Main()
    {
        Console.WriteLine("How manu numbers do you want to compare ?");
        uint n = uint.Parse(Console.ReadLine());
        int biggest = int.MinValue;
        int smallest = int.MaxValue;
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("Enter the number {0}", i);
            int input = int.Parse(Console.ReadLine());
            if (input > biggest)
            {
                biggest = input;
            }
            if (input < smallest)
            {
                smallest = input;
            }
        }
        Console.WriteLine("The biggest number is: {0}", biggest);
        Console.WriteLine("The smallest number is: {0}", smallest);
    }
}
