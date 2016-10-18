using System;
using System.Xml;

namespace _11.ExtractAlbumsOlder5YearsXpath
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";
            var pathQuery = "/catalogue/album[year<2010]/price";

            var doc = new XmlDocument();
            doc.Load(path);

            var albumsList = doc.SelectNodes(pathQuery);

            foreach (XmlNode album in albumsList)
            {
                Console.WriteLine($"{album.InnerText}$");
            }
        }
    }
}
