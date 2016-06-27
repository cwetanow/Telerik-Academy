using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2_4_8
{
    class Program
    {
        static void Main(string[] args)
        {
            long a, b, c;
            a = long.Parse(Console.ReadLine());
            b = long.Parse(Console.ReadLine());
            c = long.Parse(Console.ReadLine());
            long r;
            switch (b)
            {
                case 2: {
                    r = a % c;
                    break;
                }
                case 4: {
                    r = a + c;
                    break;
                }

                default:
                    r = a * c;
                    break;
            }
            if (r % 4 == 0)
            {
                Console.WriteLine("{0}", r / 4);
            }
            else {
                Console.WriteLine("{0}", r%4);
            }
            Console.WriteLine(r);
        }
    }
}
