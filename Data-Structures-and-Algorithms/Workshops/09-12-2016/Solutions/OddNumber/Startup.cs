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

            var counters = new HashSet<string>();

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                if (counters.Contains(input))
                {
                    counters.Remove(input);
                }
                else
                {
                    counters.Add(input);
                }
            }

            Console.WriteLine(counters.ElementAt(0));
        }
    }
}
