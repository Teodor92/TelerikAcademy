namespace _07.GreatestOfFive
{
    using System;

    public class GreatestOfFive
    {
        /// <summary>
        /// Write a program that finds the greatest of given 5 variables.
        /// </summary>
        internal static void Main()
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());
            int fourthInt = int.Parse(Console.ReadLine());
            int fifthInt = int.Parse(Console.ReadLine());

            int biggest = 0;
            if (firstInt > secondInt)
            {
                biggest = firstInt;
                if (biggest > thirdInt)
                {
                    if (biggest > fourthInt)
                    {
                        Console.WriteLine(biggest > fifthInt ? biggest : fifthInt);
                    }
                    else
                    {
                        biggest = fourthInt;
                        Console.WriteLine(biggest > fifthInt ? biggest : fifthInt);
                    }
                }
                else
                {
                    biggest = thirdInt;
                    if (biggest > fourthInt)
                    {
                        Console.WriteLine(biggest > fifthInt ? biggest : fifthInt);
                    }
                    else
                    {
                        biggest = fourthInt;
                        Console.WriteLine(biggest > fifthInt ? biggest : fifthInt);
                    }
                }
            }
            else
            {
                biggest = secondInt;
                if (biggest > thirdInt)
                {
                    if (biggest > fourthInt)
                    {
                        Console.WriteLine(biggest > fifthInt ? biggest : fifthInt);
                    }
                    else
                    {
                        biggest = fourthInt;
                        Console.WriteLine(biggest > fifthInt ? biggest : fifthInt);
                    }
                }
                else
                {
                    biggest = thirdInt;
                    if (biggest > fourthInt)
                    {
                        Console.WriteLine(biggest > fifthInt ? biggest : fifthInt);
                    }
                    else
                    {
                        biggest = fourthInt;
                        Console.WriteLine(biggest > fifthInt ? biggest : fifthInt);
                    }
                }
            }
        }
    }
}
