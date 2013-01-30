using System;

class Icecream
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int numberOfElefants = int.Parse(input[0]);
        string number = input[1];
        int counter = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] != '0')
            {
                counter++;
            }
        }
        Console.WriteLine(numberOfElefants - counter);
    }
}
