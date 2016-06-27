using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double perimeter = 2*r * Math.PI;
            double area = Math.Pow(r, 2) * Math.PI;
            Console.WriteLine("{0:F2} {1:F2}", perimeter, area);
        }
    }
}
