using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Even_differences
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long sum = 0;
            int i = 1;
            do
            {
                if (Math.Abs(numbers[i]-numbers[i-1])%2==0)
                {
                    sum += Math.Abs(numbers[i] - numbers[i - 1]);
                    i += 2;
                }
                else
                {
                    i++;
                }
            } while (i<numbers.Length);
            Console.WriteLine(sum);
        }
    }
}
