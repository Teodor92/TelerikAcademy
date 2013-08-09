using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07.XmlToTextConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../person.txt", Encoding.UTF8);
            XElement peopleXml = new XElement("people");


            using (reader)
            {
                string line = reader.ReadLine();
                int lineCount = 1;
                string name = "";
                string address = "";
                string phone = "";

                while (line != null)
                {

                    if (lineCount % 3 == 1)
                    {
                        name = line;
                    }
                    else if (lineCount % 3 == 2)
                    {
                        address = line;
                    }
                    else
                    {
                        phone = line;
                        peopleXml.Add(new XElement("person",
                        new XElement("name", name),
                        new XElement("address", address),
                        new XElement("phone", phone)
                        ));
                    }

                    lineCount++;
                    line = reader.ReadLine();
                }

            }

            Console.WriteLine("XML generated.");
            peopleXml.Save("../../peopleData.xml");
        }
    }
}
