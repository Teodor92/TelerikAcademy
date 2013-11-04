namespace PriceRangeSearch
{
    /* 
     * Write a program that finds a set of words (e.g. 1000 words) in a 
     * large text (e.g. 100 MB text file). Print how many times each word occurs in the text.
     * Hint: you may find a C# trie in Internet.
     */

    /* 
     * NOTE: Add a text.txt file with all the words in
     * the project directory ( i can't upload it with the homework do to size restrictions ) 
     */

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    public class Program
    {
        /*
         * Write a program to read a 
         * large collection of products (name + price) 
         * and efficiently find the first 20 products in the price range [a…b]. 
         * Test for 500 000 products and 10 000 price searches.
         * Hint: you may use OrderedBag<T> and sub-ranges.
         */

        private static Stopwatch myWatch = new Stopwatch();

        public static void Main()
        {
            myWatch.Start();
            
            Random randomGen = new Random();
            OrderedBag<Product> myBag = new OrderedBag<Product>();

            for (int i = 0; i < 500000; i++)
            {
                myBag.Add(new Product("Product" + i, randomGen.Next(1, 1000000)));
            }

            int start = 0;
            int end = 1000;
            for (int i = 0; i < 10000; i++)
            {
                var subBag = myBag.Range(new Product(string.Empty, start), true, new Product(string.Empty, end), true);
                IList<Product> firstTwenty = GetFirstResults(subBag);

                ////Console.WriteLine("Results");
                ////foreach (Product product in firstTwenty)
                ////{
                ////    Console.WriteLine(product);
                ////}

                start += 10;
                end += 10;
            }

            myWatch.Stop();
            Console.WriteLine("END");
            Console.WriteLine("Time: {0}", myWatch.Elapsed);
        }

        public static IList<Product> GetFirstResults(OrderedBag<Product>.View resultBag)
        {
            IList<Product> outResult = new List<Product>();
            int resultListLength = 0;

            if (resultBag.Count > 20)
            {
                resultListLength = 20;
            }
            else
            {
                resultListLength = resultBag.Count;
            }

            for (int i = 0; i < resultListLength; i++)
            {
                outResult.Add(resultBag[i]);
            }

            return outResult;
        }
    }
}
