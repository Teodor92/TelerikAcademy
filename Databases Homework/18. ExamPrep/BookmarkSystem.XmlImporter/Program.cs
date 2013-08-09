using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookmarkSystem.Data;
using BookmarkSystem.Model;
using System.Xml;

namespace BookmarkSystem.XmlImporter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            XmlDocument inportDoc = new XmlDocument();
            inportDoc.Load(@"../../bookmarks.xml");

            XmlNodeList childrenList = inportDoc.SelectNodes(@"bookmarks/bookmark");

            foreach (XmlNode item in childrenList)
            {
                string username = item.GetChildText("username");
                string title = item.GetChildText("title");
                string url = item.GetChildText("url");
                string notes = item.GetChildText("notes");
                string allTags = item.GetChildText("tags");
                string[] tags = { };

                if (allTags != null)
                {
                    tags = allTags.Split(',');
                    for (int i = 0; i < tags.Length; i++)
                    {
                        tags[i] = tags[i].Trim();
                    }
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
            else
            {
                return childNode.InnerText.Trim();
            }
        }
    }
}
