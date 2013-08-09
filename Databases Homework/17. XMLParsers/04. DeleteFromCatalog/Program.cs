using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.DeleteFromCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            {
                XmlNode node = rootNode.ChildNodes[i];

                if (double.Parse(node["price"].InnerText) > 20)
                {
                    XmlNode parent = rootNode;
                    parent.RemoveChild(node);
                    Console.WriteLine("Album deleted: {0}", node["name"].InnerText);
                }
            }


            doc.Save("../../modifiedCatalog.xml");
        }
    }
}