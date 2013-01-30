using System;

public class RandomValues
{
    public static void Main()
    {
        Random randGen = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(randGen.Next(100, 201));
        }
    }
}
