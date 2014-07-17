namespace _04.DancingBits
{
    using System;
    using System.Collections.Generic;

    public class DancingBits
    {
        internal static void Main()
        {
            var k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var allBits = new List<int>();
            for (int i = 0; i < n; i++)
            {
                uint input = uint.Parse(Console.ReadLine());
                var singleBits = new List<int>();
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
                allBits.AddRange(singleBits);
            }

            var danceCoutner = 0;
            var lenCointer = 1;
            var defaultType = -1;
            var type = defaultType;

            for (int i = allBits.Count - 1; i >= 0; i--)
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
}
