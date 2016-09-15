using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Integer_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                   .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(item => int.Parse(item))
                   .ToArray();
            Console.WriteLine(Min(numbers));
            Console.WriteLine(Max(numbers));
            Console.WriteLine("{0:F2}",Average(numbers));
            Console.WriteLine(Sum(numbers));
            Console.WriteLine(Product(numbers));
        }
        static int Min(int[] numbers) {
            return numbers.Min();
        }
        static int Max(int[] numbers)
        {
            return numbers.Max();
        }
        static int Sum(int[] numbers)
        {
            return numbers.Sum();
        }
        static double Average(int[] numbers)
        {
            return numbers.Average();
        }
        static long Product(int[] numbers)
        {
            long product = 1;
            for (int i = 0; i < 5; i++)
            {
                product*=(long)numbers[i];
            }
            return product;
        }
    }
}
