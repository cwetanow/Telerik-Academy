using System;
using System.Text;
using System.Xml;

namespace _08.CreateAlbums
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";

            // Creates the file int the main directory of the homework
            var newFilePath = "../../../../albums.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (var reader = XmlReader.Create(path))
            {
                using (var writer = new XmlTextWriter(newFilePath, encoding))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("Albums");

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                             (reader.Name == "name"))
                        {
                            writer.WriteStartElement("album");
                            writer.WriteElementString("name", reader.ReadElementString());
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) &&
                           (reader.Name == "artist"))
                        {
                            writer.WriteElementString("artist", reader.ReadElementString());
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndDocument();
                }
            }
        }
    }
}
