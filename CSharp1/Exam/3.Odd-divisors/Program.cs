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
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = a; i <=b; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (i%j==0 && j%2==1)
                    {
                        sum += j;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
