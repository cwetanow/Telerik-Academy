using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FindOccuranceTimes
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            //   var list = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var list = GetRandomNumbers();

            var counters = new Dictionary<int, int>();

            foreach (var element in list)
            {
                if (counters.ContainsKey(element))
                {
                    counters[element]++;
                }
                else
                {
                    counters[element] = 1;
                }
            }

            foreach (var counter in counters)
            {
                Console.WriteLine($"{counter.Key}-> {counter.Value} times");
            }
        }

        public static IList<int> GetRandomNumbers(int count = 20)
        {
            var result = new List<int>();

            var random = new Random();
            for (var i = 0; i < count; i++)
            {
                result.Add(random.Next(0, 1001));
            }

            var stringedList = string.Join(", ", result);
            Console.WriteLine(stringedList);

            return result;
        }
    }
}
