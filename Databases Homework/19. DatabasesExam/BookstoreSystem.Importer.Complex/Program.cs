namespace BookstoreSystem.Importer.Complex
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Transactions;
    using System.Xml;
    using BookstoreSystem.Data;

    public static class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            TransactionScope tran =	new TransactionScope(
            TransactionScopeOption.Required,
                new TransactionOptions() 
                {
                    IsolationLevel = IsolationLevel.RepeatableRead 
                });

            using (tran)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../complex-books.xml");
                string xPathQuery = "/catalog/book";

                foreach (XmlNode item in xmlDoc.SelectNodes(xPathQuery))
                {
                    string title = item.GetChildText("title");

                    List<string> authors = new List<string>();

                    foreach (XmlNode author in item.SelectNodes("authors/author"))
                    {
                        authors.Add(author.InnerText.Trim());
                    }

                    //Console.WriteLine(string.Join(", ", authors));

                    List<ReviewInfo> allReviews = new List<ReviewInfo>();
                    foreach (XmlNode review in item.SelectNodes("reviews/review"))
                    {
                        ReviewInfo newReviewInfo = new ReviewInfo();
                        newReviewInfo.Text = review.InnerText.Trim();

                        if (review.Attributes["author"] != null)
                        {
                            newReviewInfo.Author = review.Attributes["author"].Value;
                        }

                        if (review.Attributes["date"] != null)
                        {
                            newReviewInfo.Date = review.Attributes["date"].Value;
                        }

                        allReviews.Add(newReviewInfo);
                    }

                    string isbn = item.GetChildText("isbn");
                    string price = item.GetChildText("price");
                    string webSite = item.GetChildText("web-site");

                    if (!string.IsNullOrWhiteSpace(isbn) && isbn.Length != 13)
                    {
                        throw new FormatException("ISBN is in a wrong format. It must have 13 digits");
                    }

                    BookstoreSystemDLA.CreateBookComplex(title, authors, isbn, price, webSite, allReviews);
                }

                tran.Complete();
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
