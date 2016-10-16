using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ValidateXmlWithSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            var docPath = "../../../../catalogue.xml";
            var schemaPath = "../../../../catalogue.xsd";

            var doc = new XmlDocument();
            doc.Load(docPath);

            var isValid = ValidateSchema(doc, schemaPath);

            Console.WriteLine(isValid ? "Document is valid" : "Document is invalid");
        }

        public static bool ValidateSchema(XmlDocument doc, string schemaPath)
        {
            doc.Schemas.Add(null, schemaPath);

            try
            {
                doc.Validate(null);
                return true;
            }
            catch (XmlSchemaValidationException)
            {
                return false;
            }
        }
    }
}
