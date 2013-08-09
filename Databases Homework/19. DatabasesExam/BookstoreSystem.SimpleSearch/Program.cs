namespace BookstoreSystem.SimpleSearch
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml;
    using BookstoreSystem.Data;
    using BookstoreSystem.Model;
    using SearchLogger.Client;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string xPathQuery = "/query";
            IList<Book> result = null;

            Logger.AddLog(xmlDoc.SelectSingleNode("query").OuterXml);

            foreach (XmlNode item in xmlDoc.SelectNodes(xPathQuery))
            {
                string title = item.GetChildText("title");
                string author = item.GetChildText("author");
                string isbn = item.GetChildText("isbn");

                result = BookstoreSystemDLA.SimpleSearch(title, author, isbn);
            }

            Console.WriteLine("{0} book/s found!", result.Count);

            foreach (var book in result)
            {
                int numberOfReviews = book.Reviews.Count;
                if (numberOfReviews == 0)
                {
                    Console.WriteLine("{0} --> No reviews!", book.Title);
                }
                else
                {
                    Console.WriteLine("{0} --> {1} reviews.", book.Title, book.Reviews.Count);
                }
            }
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }
            
            return childNode.InnerText.Trim();
        }
    }
}
