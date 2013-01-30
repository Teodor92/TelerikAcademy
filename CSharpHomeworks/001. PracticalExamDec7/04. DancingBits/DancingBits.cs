using System;
using System.Collections.Generic;
using System.Linq;

class DancingBits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        List<int> allBits = new List<int>();
        for (int i = 0; i < n; i++)
        {
            uint input = uint.Parse(Console.ReadLine());
            List<int> singleBits = new List<int>();
            while (input > 0)
            {
                if (input % 2 == 0)
                {
                    singleBits.Add(0);
                    input = input / 2;
                }
                else
                {
                    singleBits.Add(1);
                    input = input / 2;
                }
            }
            singleBits.Reverse();
            foreach (var item in singleBits)
            {
                allBits.Add(item);
            }
        }
        //foreach (var item in allBits)
        //{
        //    Console.Write(item);
        //}
        //Console.WriteLine();
        int danceCoutner = 0;
        int lenCointer = 1;
        int defaultType = -1;
        int type = defaultType;
        
        //for (int i = ; i < allBits.Count; i++)
        //{
        //    lenCointer = 1;
        //    for (int j = i; j <= k; j++)
        //    {
        //        if (allBits[j] == allBits[j + 1])
        //        {
        //            lenCointer++;
        //        }
        //    }
        //    if (lenCointer == k)
        //    {
        //        danceCoutner++;
        //    }
        //}
        for (int i = allBits.Count-1; i >= 0; i--)
        {
            if (allBits[i] == type && type != defaultType)
            {
                lenCointer++;
            }
            else
            {
                if (lenCointer == k && type != defaultType)
                {
                    danceCoutner++;
                    
                }
                lenCointer = 1;
                type = allBits[i];
            }
        }

        if (lenCointer == k && type != -1)
        {
            danceCoutner++;

        }

        Console.WriteLine(danceCoutner);
    }
}
