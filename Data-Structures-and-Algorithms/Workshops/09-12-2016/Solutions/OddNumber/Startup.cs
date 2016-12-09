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

            var input = Console.ReadLine();

            for (var i = 0; i < n; i++)
            {
                if (counters.Contains(input))
                {
                    counters.Remove(input);
                }
                else
                {
                    counters.Add(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(counters.ElementAt(0));
        }
    }
}