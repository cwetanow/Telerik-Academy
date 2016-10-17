using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _11.ExtractAlbumsOlder5YearsXpath
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../catalogue.xml";

            var doc = new XmlDocument();
            doc.Load(path);


        }
    }
}
