using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _07.Calculate_3_
{
    
    class Program
    {
        static BigInteger fact(ulong n)
        {
            if (n == 1)
            {
                return 1;
            }
            else {
                return n * fact(n - 1);
            }
        }
        static void Main(string[] args)
        {
            ulong n, k;
            n=ulong.Parse(Console.ReadLine());
            k = ulong.Parse(Console.ReadLine());
            
            Console.WriteLine( (fact(n)) / ((fact(k))*(fact(n-k))) );
        }
    }
}
