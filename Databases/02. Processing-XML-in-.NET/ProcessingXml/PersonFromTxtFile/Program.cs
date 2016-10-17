using System.IO;
using System.Xml.Linq;

namespace PersonFromTxtFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../../phonebook.txt";

            var name = string.Empty;
            var address = string.Empty;
            var phone = string.Empty;

            using (var reader = new StreamReader(path))
            {
                name = reader.ReadLine();
                address = reader.ReadLine();
                phone = reader.ReadLine();
            }

            var personElement = new XElement("person",
                new XElement("name", name),
                new XElement("address", address),
                new XElement("phoneNumber", phone)
                );

            personElement.Save("../../../../person.xml");
        }
    }
}
