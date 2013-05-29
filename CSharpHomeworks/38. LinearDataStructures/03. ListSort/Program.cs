namespace ListSort
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            List<int> inputNumbers = new List<int>();
            bool isEndCommand = false;

            while (!isEndCommand)
            {
                string inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    isEndCommand = true;
                }
                else
                {
                    int parsedNumber = int.Parse(inputLine);
                    inputNumbers.Add(parsedNumber);
                }
            }

            Console.WriteLine("Unsorted list.");
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                Console.Write("{0}, ", inputNumbers[i]);
            }

            Console.WriteLine();

            inputNumbers.Sort();

            Console.WriteLine("Sorted list.");
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                Console.Write("{0}, ", inputNumbers[i]);
            }

            Console.WriteLine();
        }
    }
}
