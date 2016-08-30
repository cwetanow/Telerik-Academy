using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Odd_divisors
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var sum = 0;

            for (var i = a; i <= b; i++)
            {
                for (var j = 1; j <= i; j++)
                {
                    if (i % j == 0 && j % 2 == 1)
                    {
                        sum += j;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
