using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Company_info
{
    class Program
    {
        static void Main(string[] args)
        {
            string companyName = Console.ReadLine();
            string companyAddress = Console.ReadLine();
            string phoneNumber = Console.ReadLine();
            string faxNumber = Console.ReadLine();
            string website = Console.ReadLine();
            string managerFirstName= Console.ReadLine();
            string managerLastName = Console.ReadLine();
            ushort managerAge = ushort.Parse(Console.ReadLine());
            string managerPhone = Console.ReadLine();

            if (string.IsNullOrEmpty(faxNumber) ) {
                faxNumber = "(no fax)";
            }
            Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})", companyName,companyAddress, phoneNumber, faxNumber, website, managerFirstName, managerLastName, managerAge, managerPhone);

        }
    }
}
