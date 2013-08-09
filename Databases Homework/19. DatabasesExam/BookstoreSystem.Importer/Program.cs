namespace BookstoreSystem.Importer
{
    using System;
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
                xmlDoc.Load("../../simple-books.xml");
                string xPathQuery = "/catalog/book";

                foreach (XmlNode item in xmlDoc.SelectNodes(xPathQuery))
                {
                    string author = item.GetChildText("author");
                    string title = item.GetChildText("title");
                    string isbn = item.GetChildText("isbn");
                    string price = item.GetChildText("price");
                    string webSite = item.GetChildText("web-site");

                    if (!string.IsNullOrWhiteSpace(isbn) && isbn.Length != 13)
                    {
                        throw new FormatException("ISBN is in a wrong format. It must have 13 digits");
                    }

                    BookstoreSystemDLA.CreateBook(
                        author,
                        title,
                        isbn,
                        price,
                        webSite);
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
