using System;

class MissCat2011
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] cats = new int[11];
        for (int i = 0; i < n; i++)
        {
            byte vote = byte.Parse(Console.ReadLine());
            switch (vote) 
            {
                case 1: cats[1] = cats[1] + 1; 
                    break;
                case 2: cats[2] = cats[2] + 1; 
                    break;
                case 3: cats[3] = cats[3] + 1; 
                    break;
                case 4: cats[4] = cats[4] + 1; 
                    break;
                case 5: cats[5] = cats[5] + 1; 
                    break;
                case 6: cats[6] = cats[6] + 1; 
                    break;
                case 7: cats[7] = cats[7] + 1; 
                    break;
                case 8: cats[8] = cats[8] + 1; 
                    break;
                case 9: cats[9] = cats[9] + 1; 
                    break;
                case 10: cats[10] = cats[10] + 1; 
                    break;
            }

        }
        int bestCat = 0;
        for (int i = 1; i <= 10; i++)
        {
            for (int j = i; j <= 10; j++)
            {
                if (cats[j]>cats[bestCat])
                {
                    bestCat = j;
                }
                else if (cats[j] == cats[bestCat] && j < bestCat)
                {
                    bestCat = j;
                }
            }
        }
        Console.WriteLine(bestCat);
    }
}
