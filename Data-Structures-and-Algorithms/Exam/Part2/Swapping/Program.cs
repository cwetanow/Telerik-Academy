using System;
using System.Collections.Generic;
using System.Linq;

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
                .ToDictionary(num => num, num => num - 1);

            var len = initialNumbers.Count;

            foreach (var number in numbers)
            {
                var index = initialNumbers[number];

                for (var i = 1; i <= n; i++)
                {
                    var num = initialNumbers[i];
                    if (num > index)
                    {
                        initialNumbers[i] -= index + 1;
                    }
                    else if (num < index)
                    {
                        initialNumbers[i] += len - index;
                    }
                    else
                    {
                        initialNumbers[i] = len - 1 - index;
                    }
                }
            }

            var nums = initialNumbers
                .Select(num => new
                {
                    Index = num.Value,
                    Number = num.Key
                })
                .ToList();
            nums.Sort((a, b) => a.Index.CompareTo(b.Index));

            Console.WriteLine(string.Join(" ", nums.Select(x => x.Number)));
        }
    }
}
