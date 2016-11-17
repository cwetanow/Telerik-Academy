using System;
using System.Collections.Generic;

namespace _04.LongestSubsequence
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var list = new List<int>() { 4, 2, 2, 2, 5, 5, 5, 5, 5, 5, 5, 2, 3 };

            var longestSequence = GetLongestSubsequence(list);
        }

        public static List<int> GetLongestSubsequence(List<int> list)
        {
            var max = 1;
            var maxElement = list[0];

            var currentMax = 1;

            for (var i = 1; i < list.Count; i++)
            {
                var current = list[i];
                var previous = list[i - 1];

                if (current == previous)
                {
                    currentMax++;
                }
                else
                {
                    currentMax = 1;
                }

                if (currentMax > max)
                {
                    max = currentMax;
                    maxElement = list[i];
                }
            }

            var result = new List<int>();

            for (var i = 0; i < max; i++)
            {
                result.Add(maxElement);
            }

            Console.WriteLine($"Max sequence length is {max}");

            return result;
        }
    }
}
