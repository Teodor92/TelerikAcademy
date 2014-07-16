namespace _12.Cookies
{
    using System;

    public class Cookies
    {
        internal static void Main()
        {
            var input = Console.ReadLine().Split();
            var allCookies = int.Parse(input[0]);
            var hunterCookies = int.Parse(input[1]);

            if (hunterCookies > allCookies / 2)
            {
                Console.WriteLine(allCookies / 2);
            }
            else
            {
                Console.WriteLine(allCookies - hunterCookies);
            }
        }
    }
}
