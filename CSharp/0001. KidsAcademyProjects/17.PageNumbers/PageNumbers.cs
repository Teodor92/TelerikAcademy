using System;

class PageNumbers
{
    static double NumberOfDigits(int n)
    {
        double counter = 0;
        while(n!=0)
        {
            n /= 10;
            counter++;
        }
        return counter;
    }
    static void Main()
    {
       
        int pages = int.Parse(Console.ReadLine());
        int counter = 0;

        for (int i = 1; i < NumberOfDigits(pages)+1; i++)
        {
            double pow = Math.Pow(10, NumberOfDigits(pages) - i);

            int firstPage = pages / (int)pow;

            int allPages = pages - ((int)pow * firstPage);

            if (allPages / (int)pow == 0)
            {
                firstPage *= 10;
            }

            if (firstPage<allPages)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}
