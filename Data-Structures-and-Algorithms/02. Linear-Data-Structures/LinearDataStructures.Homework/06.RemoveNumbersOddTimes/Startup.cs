using System;
using System.Collections.Generic;

namespace _06.RemoveNumbersOddTimes
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var list = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var timesCount = new Dictionary<int, int>();

            foreach (var element in list)
            {
                if (timesCount.ContainsKey(element))
                {
                    timesCount[element]++;
                }
                else
                {
                    timesCount[element] = 1;
                }
            }

            foreach (var count in timesCount)
            {
                if (count.Value % 2 == 1)
                {
                    list.RemoveAll(x => x == count.Key);
                }
            }

            Console.WriteLine("Elements left");
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}
