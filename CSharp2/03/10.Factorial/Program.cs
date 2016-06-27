using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _10.Factorial
{
    class Program
    {
        static BigInteger Factorial(int n) {
            BigInteger fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
        }
    }
}
