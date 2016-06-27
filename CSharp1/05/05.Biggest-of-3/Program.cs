using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Biggest_of_3
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());
            float biggest = Math.Max(a, b);
            biggest = Math.Max(biggest, c);
            Console.WriteLine("{0}", biggest);
        }
    }
}
