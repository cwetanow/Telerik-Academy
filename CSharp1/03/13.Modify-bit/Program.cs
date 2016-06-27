using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Modify_bit
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = uint.Parse(Console.ReadLine());
            short p = short.Parse(Console.ReadLine());
            byte v = byte.Parse(Console.ReadLine());
            if ((n >> p) % 2 != v)
            {
                if (v == 0)
                {
                    n = n-(ulong)Math.Pow(2, p);

                }
                else {
                    n = n+ (ulong)Math.Pow(2, p);
                }
            }
            Console.WriteLine(n);

        }
    }
}
