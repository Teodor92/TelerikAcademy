namespace StackReverse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter the amount of numbers:");
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            Console.WriteLine("Enter the numbers:");
            for (int i = 0; i < n; i++)
            {
                int inputNumner = int.Parse(Console.ReadLine());
                numbers.Push(inputNumner);
            }

            Console.WriteLine("Number reversed.");
            Console.WriteLine(StackUtils.ReverseNumbers(numbers));
        }
    }
}
