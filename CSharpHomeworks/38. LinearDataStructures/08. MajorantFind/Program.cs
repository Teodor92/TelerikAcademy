namespace MajorantFind
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int[] sequence = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            int majoriant = IListUtils.FindMajorant(sequence);

            Console.WriteLine("The majorant is: {0}", majoriant);
        }
    }
}
