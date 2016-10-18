using System;
using System.Xml.Xsl;

namespace _14.StylesheetTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlPath = "../../../../catalogue.xml";
            var xsltPath = "../../../../catalogueStylesheet.xslt";
            var htmlPath = "../../catalogue.html";

            var xslt = new XslCompiledTransform();
            xslt.Load(xsltPath);

            xslt.Transform(xmlPath, htmlPath);
        }
    }
}
