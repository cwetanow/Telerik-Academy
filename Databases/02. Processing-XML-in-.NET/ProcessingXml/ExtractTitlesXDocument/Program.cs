using System;
using System.Linq;
using System.Xml.Linq;

namespace ExtractTitlesXDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";

            var doc = XDocument.Load(path);

            var titles = doc.Root.Descendants("title")
                .Select(x => x.Value);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
