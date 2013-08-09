using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsumingWebServices
{
    public static class UI
    {
        public static void Load(ArticleProvider provider)
        {
            Console.WriteLine("Enter a query string to search for:");
            string queryString = Console.ReadLine();

            Console.WriteLine("Enter a number of articles to display. (Hit enter if you want to see all of them)");
            string articleCount = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(articleCount))
            {
                PrintSearchBox(true);

                AllArticles articles = provider.GetArticles(queryString);

                foreach (var article in articles.Articles)
                {
                    PrintResultBox(article);
                }
            }
            else
            {
                PrintSearchBox(false);

                AllArticles articles = provider.GetArticles(queryString, int.Parse(articleCount));

                foreach (var article in articles.Articles)
                {
                    PrintResultBox(article);
                }
            }
        }

        private static void PrintResultBox(Article article)
        {
            Console.WriteLine(new string('-', Console.WindowWidth - 5));
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Title: {0}", article.Title);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Url: {0}", article.Url);
            Console.ResetColor();
            Console.WriteLine(new string('-', Console.WindowWidth - 5));
        }

        private static void PrintSearchBox(bool byQueryStringAndCount)
        {
            if (byQueryStringAndCount)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(new string('=', Console.WindowWidth - 5));
                Console.WriteLine("Search result by query string and count.");
                Console.WriteLine(new string('=', Console.WindowWidth - 5));
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new string('=', Console.WindowWidth - 5));
                Console.WriteLine("Search result by query string");
                Console.WriteLine(new string('=', Console.WindowWidth - 5));
                Console.ResetColor();
            }
        }
    }
}
