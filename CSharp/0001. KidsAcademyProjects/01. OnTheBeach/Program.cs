using System;

    class Program
    {
        static void Main()
        {
            string[] result = Console.ReadLine().Split(' ');
            int[] res1 = new int[8];
            for (int i = 0; i < 8; i++)
            {
                res1[i] = int.Parse(result[i]);
            }
            if (res1[4]-res1[1] > 0)
            {
                Console.Write(res1[4]);
                Console.Write(res1[5]);
            }
            else
            {
                Console.Write(res1[0]);
                Console.Write(res1[1]);
            }
            if (res1[6] - res1[2] > 0)
            {
                Console.Write(res1[2]);
                Console.Write(res1[3]);
            }
            else
            {
                Console.Write(res1[6]);
                Console.Write(res1[7]);
            }
        }
    }
