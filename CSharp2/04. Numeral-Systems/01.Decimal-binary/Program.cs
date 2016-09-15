using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Decimal_binary
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            string binary = Convert.ToString(n, 2);
            Console.WriteLine(binary);
        }
    }
}
