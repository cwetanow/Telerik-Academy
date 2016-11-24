using System;
using System.Collections.Generic;

namespace _03.Separators
{
    public class Startup
    {
        private static readonly List<int> Combinations = new List<int>();
        private static readonly IList<int> numbers = new List<int>();

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            FilterNumbers();

            var result = GetNumber();
            Console.WriteLine(result);
        }

        private static int GetNumber()
        {
            GenerateCombinations();
            Combinations.Sort();

            var result = Combinations[0];
            var separators = GetSeparators(result);

            foreach (var combination in Combinations)
            {
                var separatorCount = GetSeparators(combination);
                if (separatorCount < separators)
                {
                    result = combination;
                    separators = separatorCount;
                }
            }

            return result;
        }

        static int GetSeparators(int number)
        {
            var result = 2;

            for (var i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    ++result;
                }
            }

            return result;
        }

        private static void GenerateCombinations()
        {
            foreach (var number in numbers)
            {
                GetCombinations(number.ToString());
            }
        }

        private static void GetCombinations(string result)
        {
            if (result.Length == numbers.Count)
            {
                Combinations.Add(int.Parse(result));
                return;
            }

            foreach (var number in numbers)
            {
                if (!result.Contains(number.ToString()))
                {
                    GetCombinations(result + number);
                }
            }
        }

        private static void FilterNumbers()
        {
            var counters = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (counters.ContainsKey(number))
                {
                    counters[number]++;
                }
                else
                {
                    counters[number] = 1;
                }
            }

            foreach (var counter in counters)
            {
                if (counter.Value > 1)
                {
                    while (numbers.Contains(counter.Key))
                    {
                        numbers.Remove(counter.Key);
                    }

                    numbers.Add(counter.Key);
                }
            }
        }
    }
}