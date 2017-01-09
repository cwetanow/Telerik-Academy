using System;
using System.Collections.Generic;
using System.Linq;

namespace RingsOfAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var rings = new List<int>();

            for (var i = 0; i < n; i++)
            {
                var ring = int.Parse(Console.ReadLine());
                rings.Add(ring);
            }

            var result = 1;

            var grouped = rings.GroupBy(x => x);

            foreach (var group in grouped)
            {
                var count = group.Count();
                result *= Factorial(count);
            }

            Console.WriteLine(result);
        }

        private static int Factorial(int n)
        {
            for (int i = n - 1; i > 0; i--)
            {
                n *= i;
            }

            return n;
        }
    }
}
