using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Moon_gravity
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal W = decimal.Parse(Console.ReadLine());
            W = (W * 17) / 100;
            Console.WriteLine(string.Format("{0:0.000}", W));
        }
    }
}
