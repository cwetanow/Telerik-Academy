using System;
using System.Xml;

namespace ExtractTitlesXmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";

            using (var reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementContentAsString());
                    }
                }
            }
        }
    }
}
