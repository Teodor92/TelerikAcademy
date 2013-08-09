using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _08.AlbumWrite
{
    class Program
    {
        static void Main()
        {
            XmlTextWriter writer = new XmlTextWriter("../../album.xml", Encoding.UTF8);

            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("albums");

                string name = string.Empty;
                using (XmlReader reader = XmlReader.Create("../../catalog.xml"))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "name"))
                        {
                            name = reader.ReadElementString();
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "artist"))
                        {
                            string artist = reader.ReadElementString();
                            WriteAlbum(writer, name, artist);
                        }
                    }
                }
                writer.WriteEndDocument();
                Console.WriteLine("Document album.xml was created.");
            }
        }
        private static void WriteAlbum(XmlWriter writer, string name, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }
    }
}
