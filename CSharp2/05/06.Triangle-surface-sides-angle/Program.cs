using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Triangle_surface_sides_angle
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());
            double area = (a * b * Math.Sin(angle * Math.PI/180))/2;
            Console.WriteLine("{0:F2}",area);
        }
    }
}
