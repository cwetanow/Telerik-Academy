using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Majorant
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var list = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var counters = GetOccuranceTimes(list);

            var majorant = GetMajorant(counters, list.Count);

            Console.WriteLine(majorant == null ? "There is no majorant" : $"Majorant is {majorant}");
        }

        public static int? GetMajorant(IDictionary<int, int> counters, int listLength)
        {
            var criteria = listLength / 2 + 1;

            int? majorant = counters.FirstOrDefault(c => c.Value == counters.Values.Max()).Key;

            return counters[majorant.Value] >= criteria ? majorant : null;
        }

        public static IDictionary<int, int> GetOccuranceTimes(IList<int> list)
        {
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

            return counters;
        }
    }
}
