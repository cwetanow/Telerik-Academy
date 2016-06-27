using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Point_in_circle
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double distance = Math.Sqrt(x * x + y * y);
            if (distance<=2)
            {
                Console.WriteLine("yes " + string.Format("{0:0.00}", distance));
            }
            else {
                Console.WriteLine("no " + string.Format("{0:0.00}", distance));
            }


        }
    }
}
