namespace TradeCompanyArticles
{
    using System;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            Random randGen = new Random();
            OrderedMultiDictionary<Article, int> articles = new OrderedMultiDictionary<Article, int>(false);

            for (int i = 0; i < 100; i++)
            {
                Article myArticle = new Article(randGen.Next(10000, 99999), "Vendor" + i, "Title" + i, randGen.Next(1000, 9999));

                if (!articles.ContainsKey(myArticle))
                {
                    articles.Add(myArticle, 1);
                }
            }

            Console.WriteLine("Enter bottom price:");
            int startPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter top price:");
            int endPrice = int.Parse(Console.ReadLine());

            OrderedMultiDictionary<Article, int>.View neededArticles = articles.Range(
                new Article(0, string.Empty, string.Empty, 2000),
                true,
                new Article(0, string.Empty, string.Empty, 4000),
                true);

            foreach (var item in neededArticles)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
