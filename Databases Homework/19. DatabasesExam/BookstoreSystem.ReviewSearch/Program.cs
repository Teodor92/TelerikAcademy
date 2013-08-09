namespace BookstoreSystem.ReviewSearch
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Xml;
    using BookstoreSystem.Data;
    using BookstoreSystem.Model;
    using SearchLogger.Client;

    public static class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string fileName = "../../search-results.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                ProcessSearchQuery(writer);

                writer.WriteEndDocument();
            }		
        }

        public static void ProcessSearchQuery(XmlTextWriter writer)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../reviews-queries.xml");
            string xPathQuery = "/review-queries/query";
            List<IEnumerable<Review>> allRezults = new List<IEnumerable<Review>>();

            foreach (XmlElement item in xmlDoc.SelectNodes(xPathQuery))
            {
                Logger.AddLog(item.OuterXml);
                //Console.WriteLine(item.OuterXml);


                if (item.GetAttribute("type") == "by-period")
                {
                    DateTime startDate = DateTime.Parse(item.GetChildText("start-date"));
                    DateTime endDate = DateTime.Parse(item.GetChildText("end-date"));
                    IEnumerable<Review> searchResult = 
                        BookstoreSystemDLA.FindReviewsByDates(startDate, endDate)
                        .OrderBy(x => x.DateOfCreation)
                        .ThenBy(x => x.ReviewText);

                    allRezults.Add(searchResult);
                }

                if (item.GetAttribute("type") == "by-author")
                {
                    string authName = item.GetChildText("author-name");
                    IEnumerable<Review> queryResult = 
                        BookstoreSystemDLA.FindReviewsByAuthor(authName)
                        .OrderBy(x => x.DateOfCreation)
                        .ThenBy(x => x.ReviewText);

                    allRezults.Add(queryResult);
                }
            }

            WriteResults(writer, allRezults);
            IList<Book> result = null;
        }

        private static void WriteResults(
        XmlTextWriter writer, List<IEnumerable<Review>> searchResults)
        {
            writer.WriteStartElement("search-results");
            foreach (var searchSet in searchResults)
            {
                writer.WriteStartElement("result-set");
                foreach (var result in searchSet)
                {
                    writer.WriteStartElement("review");

                    if (result.DateOfCreation != null)
                    {
                        writer.WriteElementString("date", ((DateTime)result.DateOfCreation).ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture));
                    }

                    if (!string.IsNullOrWhiteSpace(result.ReviewText))
                    {
                        writer.WriteElementString("content", result.ReviewText);
                    }

                    writer.WriteStartElement("book");

                    if (!string.IsNullOrWhiteSpace(result.Book.Title))
                    {
                        writer.WriteElementString("title", result.Book.Title);
                    }

                    if (result.Book.Authors != null)
                    {
                        StringBuilder allAuthors = new StringBuilder();

                        foreach (var item in result.Book.Authors)
                        {
                            allAuthors.AppendFormat("{0}, ", item.AuthorName);
                        }

                        writer.WriteElementString("authors", allAuthors.ToString().Trim(new char[] { ',', ' ' }));
                    }

                    if (!string.IsNullOrWhiteSpace(result.Book.ISBN))
                    {
                        writer.WriteElementString("isbn", result.Book.ISBN);
                    }

                    if (!string.IsNullOrWhiteSpace(result.Book.WebSite))
                    {
                        writer.WriteElementString("web-site", result.Book.WebSite);
                    }

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private static string GetChildText(this XmlElement node, string tagName)
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
