using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _06.Calculate_again
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n, k;
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            BigInteger fact = 1;
            for (int i = (int)k+1; i < n+1; i++)
            {
                fact *= i;
            }
            Console.WriteLine(fact);
        }
    }
}
