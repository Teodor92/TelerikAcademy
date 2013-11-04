using System;

class Hotels
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split();
        int[] hotelsHeight = new int[input.Length];
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            hotelsHeight[i] = int.Parse(input[i]);
        }
        int firstCounter = 1;
        int lowestHotel = hotelsHeight[0];
        int secondCoutner = 1;
        for (int i = 1; i < hotelsHeight.Length; i++)
        {
            if (lowestHotel < hotelsHeight[i])
            {
                lowestHotel = hotelsHeight[i];
                firstCounter++;
            }
        }
        Array.Reverse(hotelsHeight);
        lowestHotel = hotelsHeight[0];
        for (int i = 1; i < hotelsHeight.Length; i++)
        {
            if (lowestHotel < hotelsHeight[i])
            {
                lowestHotel = hotelsHeight[i];
                secondCoutner++;
            }
        }
        Console.WriteLine("{0} {1}", firstCounter, secondCoutner);
    }
}
