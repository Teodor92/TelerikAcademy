using System;

class Cookies
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int allCookies = int.Parse(input[0]);
        int hunterCookies = int.Parse(input[1]);
        if (hunterCookies > allCookies/2)
        {
            Console.WriteLine(allCookies/2);
        }
        else
        {
            Console.WriteLine(allCookies - hunterCookies);
        }
    }
}
