namespace _01.SimpleArray
{
    using System;

    /// <summary>
    /// Write a program that allocates array of 
    /// 20 integers and initializes each element
    /// by its index multiplied by 5. Print the
    /// obtained array on the console.
    /// </summary>
    public class SimpleArray
    {
        internal static void Main()
        {
            var indexArray = new int[20];
            for (int i = 0; i < indexArray.Length; i++)
            {
                indexArray[i] = i * 5;
            }

            for (int i = 0; i < indexArray.Length; i++)
            {
                Console.Write(indexArray[i]);
            }

            Console.WriteLine();
        }
    }
}
