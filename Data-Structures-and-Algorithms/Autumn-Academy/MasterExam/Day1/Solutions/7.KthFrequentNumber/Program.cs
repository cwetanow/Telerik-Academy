using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.KthFrequentNumber
{
    public class Program
    {
        class NumberCounter
        {
            public int Number { get; set; }

            public int Count { get; set; }
        }

        public static void Main(string[] args)
        {
            var input = string.Empty;

            var all = new Dictionary<int, int>();

            while ((input = Console.ReadLine()) != "END")
            {
                var splitted = input.Split(' ');

                var command = splitted[0];
                var number = int.Parse(splitted[1]);

                if (command == "ADD")
                {
                    if (all.ContainsKey(number))
                    {
                        all[number]++;
                    }
                    else
                    {
                        all.Add(number, 1);
                    }

                    Console.WriteLine($"Ok: {number} added");
                }
                else if (command == "REMOVE")
                {
                    if (all.ContainsKey(number))
                    {
                        all[number]--;
                        if (all[number] == 0)
                        {
                            all.Remove(number);
                        }

                        Console.WriteLine($"OK: Number { number} removed");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Number {number} not found");
                    }
                }
                else
                {
                    if (all.Count < number)
                    {
                        Console.WriteLine($"Error: {number} is invalid K");
                    }
                    else
                    {

                        var result = all
                            .OrderByDescending(n => n.Value)
                            .ThenBy(n => n.Key)
                            .Select(n => n.Key)
                            .ToArray();

                        Console.WriteLine($"Ok: Found {result[number - 1]}");
                    }
                }

            }
        }
    }
}
