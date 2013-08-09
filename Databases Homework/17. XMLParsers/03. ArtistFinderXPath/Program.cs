using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _03.ArtistFinderXPath
{
    /* 
     * Write program that extracts all different artists which
     * are found in the catalog.xml. For each author you
     * should print the number of albums in the catalogue.
     * Implement the previous using XPath. 
     */
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\catalog.xml");
            Console.WriteLine("Document Loaded");

            string xPathQuery = "/catalogue/artist";

            XmlNodeList artistList = doc.SelectNodes(xPathQuery);
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (XmlNode artist in artistList)
            {
                var artistName = artist.Attributes["name"].Value;
                var albumsCount = artist.ChildNodes.Count;

                if (!dic.ContainsKey(artistName))
                {
                    dic.Add(artistName, albumsCount);
                }
            }

            foreach (var artist in dic)
            {
                Console.WriteLine(artist.Key + " " + artist.Value);
            }
        }
    }
}
