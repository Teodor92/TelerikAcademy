namespace _02.ArtistFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> diffrentAlbums = new Dictionary<string, int>();

            XmlDocument catalog = new XmlDocument();
            catalog.Load(@"../../catalog.xml");

            XmlElement root = catalog.DocumentElement;

            foreach (XmlElement item in root.ChildNodes)
            {
                string currentAuthor = item["artist"].InnerText.Trim();

                if (diffrentAlbums.ContainsKey(currentAuthor))
                {
                    foreach (var song in item["songs"])
                    {
                        diffrentAlbums[currentAuthor]++;
                    }
                }
                else
                {
                    diffrentAlbums.Add(currentAuthor, 0);

                    foreach (var song in item["songs"])
                    {
                        diffrentAlbums[currentAuthor]++;
                    }
                }

                //Console.WriteLine(item.InnerXml);

                //Console.WriteLine(item["name"].InnerText.Trim());

                //foreach (XmlElement song in item["songs"])
                //{
                //    Console.WriteLine(song["title"].InnerText);   
                //}
            }

            foreach (var artist in diffrentAlbums)
            {
                Console.WriteLine("Artist: {0}, Number of songs: {1}", artist.Key, artist.Value);
            }
        }
    }
}
