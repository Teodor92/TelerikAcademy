namespace _04.Hotels
{
    using System;

    public class Hotels
    {
        internal static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split();
            var hotelsHeight = new int[input.Length];

            for (int i = 0; i < n; i++)
            {
                hotelsHeight[i] = int.Parse(input[i]);
            }

            var firstCounter = 1;
            var lowestHotel = hotelsHeight[0];
            var secondCoutner = 1;

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
}
