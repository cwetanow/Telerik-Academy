using System;
using System.Collections.Generic;
using System.Linq;

namespace OddNumber
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var counters = new Dictionary<string, int>();

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                if (counters.ContainsKey(input))
                {
                    counters[input]++;
                }
                else
                {
                    counters[input] = 1;
                }
            }

            var result = counters.FirstOrDefault(x => x.Value % 2 == 1);

            Console.WriteLine(result.Key);
        }
    }
}
