using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _08.Catalan_numbers
{
    class Program
    {
        static BigInteger faktoriel(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * faktoriel(n - 1);
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((faktoriel(2*n))/(faktoriel(n+1)*faktoriel(n)));
        }
    }
}
