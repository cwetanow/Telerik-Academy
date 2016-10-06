using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Fibonacci_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort n = ushort.Parse(Console.ReadLine());
            ulong[] fibonacci = new ulong[50];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < n; i++)
            {
                fibonacci[i] = fibonacci[i - 2] + fibonacci[i - 1];
            }
            for (int i = 0; i < n; i++)
            {
                if (i == (n - 1))
                {
                    Console.Write("{0} ", fibonacci[i]);
                }
                else
                {
                    Console.Write("{0}, ", fibonacci[i]);
                }

            }
            
        }
    }
}
