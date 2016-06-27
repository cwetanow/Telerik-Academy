using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Quadratic_equation
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());
            double d = Math.Pow(b, 2)-4*a*c;
            if (d > 0) {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("{0:F2}\n{1:F2}", Math.Min(x1,x2), Math.Max(x1,x2));
            }
            else if (d == 0)
            {
                double x = (-b / (2 * a));
                Console.WriteLine("{0:F2}", x);
            }
            else {
                Console.WriteLine("no real roots");
            }
        }
    }
}
