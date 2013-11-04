namespace HashTableImplement
{
    using System;

    public class Program
    {
        public static void Main()
        {
            HashTable<string, int> myHashTable = new HashTable<string, int>();

            for (int i = 0; i < 20; i++)
            {
                myHashTable["gosho" + i] = i;
            }
        }
    }
}
