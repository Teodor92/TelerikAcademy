namespace _17.PageNumbers
{
    using System;

    public class PageNumbers
    {
        internal static void Main()
        {
            var pages = int.Parse(Console.ReadLine());
            var counter = 0;

            for (int i = 1; i < NumberOfDigits(pages) + 1; i++)
            {
                var pow = Math.Pow(10, NumberOfDigits(pages) - i);

                var firstPage = pages / (int)pow;

                var allPages = pages - ((int)pow * firstPage);

                if (allPages / (int)pow == 0)
                {
                    firstPage *= 10;
                }

                if (firstPage < allPages)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        private static double NumberOfDigits(int n)
        {
            double counter = 0;
            while (n != 0)
            {
                n /= 10;
                counter++;
            }

            return counter;
        }
    }
}
