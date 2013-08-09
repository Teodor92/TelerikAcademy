namespace KnapsackProblem
{
    /* 
     * Write a program based on dynamic programming to solve the "Knapsack Problem": you are given N products, each has weight Wi and costs Ci and a knapsack of capacity M and you want to put inside a subset of the products with highest cost and weight ≤ M. The numbers N, M, Wi and Ci are integers in the range [1..500]. Example: M=10 kg, N=6, products:
     * beer – weight=3, cost=2
     * vodka – weight=8, cost=12
     * cheese – weight=4, cost=5
     * nuts – weight=1, cost=4
     * ham – weight=2, cost=3
     * whiskey – weight=8, cost=13
     */

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Item[] items = new Item[]
            {
                new Item("beer", 3, 2),
                new Item("vodka", 8, 12),
                new Item("cheese", 4, 5),
                new Item("nuts", 1, 4),
                new Item("ham", 2, 3),
                new Item("whiskey", 8, 13),
            };

            int capacity = 10;

            Console.WriteLine("Best choice: ");

            Console.WriteLine(string.Join(" ", KnapsackDynamic(items, capacity).Select(r => r.Name)));
        }

        public static List<Item> KnapsackDynamic(Item[] items, int capacity)
        {
            if (capacity == 0)
            {
                return new List<Item>();
            }

            if (items.Length == 0)
            {
                return new List<Item>();
            }

            int[,] valuesArray = new int[items.Length, capacity + 1];

            int[,] keepArray = new int[items.Length, capacity + 1];

            for (int x = 0; x <= items.Length - 1; x++)
            {
                valuesArray[x, 0] = 0;
                keepArray[x, 0] = 0;
            }

            for (int y = 1; y <= capacity; y++)
            {
                if (items[0].Weight <= y)
                {
                    valuesArray[0, y] = items[0].Value;
                    keepArray[0, y] = 1;
                }
                else
                {
                    valuesArray[0, y] = 0;
                    keepArray[0, y] = 0;
                }
            }

            for (int x = 0; x <= items.Length - 2; x++)
            {
                for (int y = 1; y <= capacity; y++)
                {
                    var currentItem = items[x + 1];

                    if (currentItem.Weight > y)
                    {
                        valuesArray[x + 1, y] = valuesArray[x, y];

                        continue;
                    }

                    int valueWhenDropping = valuesArray[x, y];
                    int valueWhenTaking = valuesArray[x, y - currentItem.Weight] + currentItem.Value;

                    if (valueWhenTaking > valueWhenDropping)
                    {
                        valuesArray[x + 1, y] = valueWhenTaking;
                        keepArray[x + 1, y] = 1;
                    }
                    else
                    {
                        valuesArray[x + 1, y] = valueWhenDropping;
                        keepArray[x + 1, y] = 0;
                    }
                }
            }

            var bestItems = new List<Item>();
            {
                int remainingSpace = capacity;
                int item = items.Length - 1;

                while (item >= 0 && remainingSpace >= 0)
                {
                    if (keepArray[item, remainingSpace] == 1)
                    {
                        bestItems.Add(items[item]);
                        remainingSpace -= items[item].Weight;
                        item -= 1;
                    }
                    else
                    {
                        item -= 1;
                    }
                }
            }

            return bestItems;
        }

    }
}