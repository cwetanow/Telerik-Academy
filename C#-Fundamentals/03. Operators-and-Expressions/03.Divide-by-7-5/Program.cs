using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Divide_by_7_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            bool condition;
            if (d % 35 == 0)
            {
                condition = true;
                Console.WriteLine("true " + d);
            }
            else {
                condition = false;
                Console.WriteLine("false "+d);
            }
        }
    }
}
