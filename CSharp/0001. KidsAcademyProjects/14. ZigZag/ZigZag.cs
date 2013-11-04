using System;

class ZigZag
{
    static bool Begining( int position, int[] numbers)
    {
        bool positive = true;
        for (int i = position; i < numbers.Length-1; i++)
        {
            if ((numbers[i + 1] - numbers[i]) > 0)
            {
                positive = true;
                break;
            }
            else if ((numbers[i + 1] - numbers[i]) < 0)
            {
                positive = false;
                break;
            }
        }
        return positive;
    }
    static int BeginingPostiton(int position, int[] numbers)
    {
        int postion = 0;
        for (int i = position; i < numbers.Length-1; i++)
        {
            if ((numbers[i + 1] - numbers[i]) > 0)
            {
                postion = i;
                break;
            }
            else if ((numbers[i + 1] - numbers[i]) < 0)
            {
                postion = i;
                break;
            }
            else
            {
                continue;
            }
        }
        return position;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        string[] stringNumeres = Console.ReadLine().Split(' ');
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(stringNumeres[i]);
        }
        int sequnceCounter = 1;
        int bestSequnceCounter = int.MinValue;
        bool cheker = Begining(1, numbers);
        bool positive = true;

        for (int i = 0; i < numbers.Length-1; i++)
        {
            if (n == 0)
            {
                Console.WriteLine(0);
                break;
            }
            if ((numbers[i+1]-numbers[i]) > 0 )
            {
                positive = true;
            }
            else if ((numbers[i + 1] - numbers[i]) < 0)
            {
                positive = false;
            }
            else
            {
                cheker = Begining(i, numbers);
                i = BeginingPostiton(i, numbers);
                continue;
            }

            if (cheker == positive)
            {
                cheker = !cheker;
                sequnceCounter++;
            }
            else
            {
                sequnceCounter = 1;
            }

            if (sequnceCounter > bestSequnceCounter)
            {
                bestSequnceCounter = sequnceCounter;
            }


        }
        Console.WriteLine(bestSequnceCounter);
    }
}
