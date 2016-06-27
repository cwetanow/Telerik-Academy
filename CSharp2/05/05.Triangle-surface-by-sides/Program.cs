using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Triangle_surface_by_sides
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double p = a + b + c;
            p /= 2;
            double area = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            Console.WriteLine("{0:F2}",area);
        }
    }
}
