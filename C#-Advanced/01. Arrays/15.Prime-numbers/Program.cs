using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Prime_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] primes = new bool[n];
            for (int i = 0; i < n; i++)
            {
                primes[i] = true;
            }
            int p = 2;
            double squareOfN = Math.Sqrt(n);
            for (int i = 1; i <= squareOfN; i++)
            {
                for (int j = 2 * p; j <= n; j += p)
                {
                    primes[j - 1] = false;
                }
                if (i < 3)
                {
                    continue;
                }
                else if (primes[i - 1])
                {
                    p = i;
                }
            }
            for (int i = n-1; i >-1; i--)
            {
                if (primes[i])
                {
                    Console.WriteLine(i+1);
                    break;
                }
            }

        }
    }
}
