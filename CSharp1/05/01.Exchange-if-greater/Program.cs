using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Exchange_if_greater
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse((Console.ReadLine()));
            double b = double.Parse((Console.ReadLine()));
            double c;
            if (a>b)
            {
             c=a;
             a=b;
                b=c;

            }
            Console.WriteLine("{0} {1}", a,b);

        }

    }
}
