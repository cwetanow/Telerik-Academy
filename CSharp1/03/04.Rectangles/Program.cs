using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double perimeter = 2 * (width + height);
            double area = width * height;
            Console.Write(string.Format("{0:0.00}", area) + " " + string.Format("{0:0.00}", perimeter));
           

        }
    }
}
