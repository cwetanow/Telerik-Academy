using System;
using System.Linq;
using System.Xml;

namespace DeleteAlbumsDOM
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";

            var doc = new XmlDocument();
            doc.Load(path);

            var costyAlbums = doc.GetElementsByTagName("album")
                .Cast<XmlNode>()
                .Where(x => double.Parse(x["price"].InnerText) > 20);

            foreach (XmlNode costyAlbum in costyAlbums)
            {
                doc.RemoveChild(costyAlbum);
            }
        }
    }
}
