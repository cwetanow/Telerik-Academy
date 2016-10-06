using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps = 0.000001;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            
            if ((a - b) < eps && (b-a)<eps)
            {
                Console.WriteLine("true");
            }
            else {
                Console.WriteLine("false");
            }
        }
    }
}
