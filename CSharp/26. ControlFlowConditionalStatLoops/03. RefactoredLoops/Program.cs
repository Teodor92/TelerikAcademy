namespace RefactoredLoops
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int expectedValue = 20;
            bool valueFound = false;
            int[] array = new int[100];

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);

                    if (array[i] == expectedValue)
                    {
                        valueFound = true;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }

            // More code here
            if (valueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
