using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sort_3_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            short a = short.Parse(Console.ReadLine());
            short b = short.Parse(Console.ReadLine());
            short c = short.Parse(Console.ReadLine());
            if (a>b)
            {
                if (a > c)
                {
                    if (b > c)
                    {
                        Console.WriteLine("{0} {1} {2}", a, b, c);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", a, c, b);
                    }
                }
                else {
                    Console.WriteLine("{0} {1} {2}", c, a, b);
                }
            }
            else if (b > c)
            {
                if (c > a)
                {
                    Console.WriteLine("{0} {1} {2}", b, c, a);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", b, a, c);
                }
            }
            else {
                Console.WriteLine("{0} {1} {2}", c, b, a);
            }
        }
    }
}
