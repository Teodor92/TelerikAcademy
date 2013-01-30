using System;

class FallDown
{
    static void Main()
    {
        byte[,] allNumbers = new byte[8,8];
        //input
        for (int row = 0; row < allNumbers.GetLength(0); row++)
        {
            byte number = byte.Parse(Console.ReadLine());
            for (int col = allNumbers.GetLength(1)-1; col > -1; col--)
            {
                if (number % 2 != 0)
                {
                    allNumbers[row, col] = 1;
                }
                number = (byte)(number / 2);
            }
        }
        // main logic
        for (int i = 0; i < 10; i++)
        {
            for (int row = 0; row < allNumbers.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < allNumbers.GetLength(1); col++)
                {
                    if (allNumbers[row, col] != 1)
                    {
                        if (allNumbers[row + 1, col] == 1)
                        {
                            allNumbers[row, col] = 1;
                            allNumbers[row + 1, col] = 0;
                        }
                    }
                }
            }
        }
        //output
        for (int row = allNumbers.GetLength(0) - 1; row > - 1 ; row--)
        {
            int sum = 0;
            for (int col = 0; col < allNumbers.GetLength(1); col++)
            {
                if (allNumbers[row, col] == 1)
                {
                    sum = sum + (int)Math.Pow(2, 7 - col);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
