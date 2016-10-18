using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace _12.ExtractAlbumsOlder5YearsLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";

            var doc = XDocument.Load(path);

            var albumsList = doc.Descendants("album");

            var prices = albumsList
                .Where(x => int.Parse(x.Element("year").Value) < 2011)
                .Select(x => new
                {
                    Price = x.Element("price").Value,
                    Name = x.Element("name").Value
                });

            foreach (var price in prices)
            {
                Console.WriteLine($"{price.Name} : {price.Price}$");
            }
        }
    }
}
