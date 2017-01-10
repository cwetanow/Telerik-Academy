using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapping
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var initialNumbers = Enumerable.Range(1, n)
                .ToList();

            foreach (var number in numbers)
            {
                var index = initialNumbers.IndexOf(number);

                var left = initialNumbers.GetRange(0, index);
                var right = initialNumbers.GetRange(index + 1, n - index - 1);

                initialNumbers.Clear();

                initialNumbers.AddRange(right);
                initialNumbers.Add(number);
                initialNumbers.AddRange(left);
            }

            var result = string.Join(" ", initialNumbers);
            Console.WriteLine(result);
        }
    }
}
