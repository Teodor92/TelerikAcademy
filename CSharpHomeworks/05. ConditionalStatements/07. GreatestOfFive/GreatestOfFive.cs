/* Write a program that finds the greatest of given 5 variables.
 */
using System;

class GreatestOfFive
{
    static void Main()
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
                    if (biggest > fifthInt)
                    {
                        Console.WriteLine(biggest);
                    }
                    else
                    {
                        Console.WriteLine(fifthInt);
                    }
                }
                else
                {
                    biggest = fourthInt;
                    if (biggest > fifthInt)
                    {
                        Console.WriteLine(biggest);
                    }
                    else
                    {
                        Console.WriteLine(fifthInt);
                    }
                }
            }
            else
            {
                biggest = thirdInt;
                if (biggest > fourthInt)
                {
                    if (biggest > fifthInt)
                    {
                        Console.WriteLine(biggest);
                    }
                    else
                    {
                        Console.WriteLine(fifthInt);
                    }
                }
                else
                {
                    biggest = fourthInt;
                    if (biggest>fifthInt)
                    {
                        Console.WriteLine(biggest);
                    }
                    else
                    {
                        Console.WriteLine(fifthInt);
                    }
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
                    if (biggest > fifthInt)
                    {
                        Console.WriteLine(biggest);
                    }
                    else
                    {
                        Console.WriteLine(fifthInt);
                    }
                }
                else
                {
                    biggest = fourthInt;
                    if (biggest > fifthInt)
                    {
                        Console.WriteLine(biggest);
                    }
                    else
                    {
                        Console.WriteLine(fifthInt);
                    }
                }
            }
            else
            {
                biggest = thirdInt;
                if (biggest > fourthInt)
                {
                    if (biggest > fifthInt)
                    {
                        Console.WriteLine(biggest);
                    }
                    else
                    {
                        Console.WriteLine(fifthInt);
                    }
                }
                else
                {
                    biggest = fourthInt;
                    if (biggest > fifthInt)
                    {
                        Console.WriteLine(biggest);
                    }
                    else
                    {
                        Console.WriteLine(fifthInt);
                    }
                }
            }
        }
    }
}
