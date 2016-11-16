using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SequenceOfElements
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var elements = new List<int>();

            while (!string.IsNullOrEmpty(input))
            {
                var element = int.Parse(input);
                elements.Add(element);

                input = Console.ReadLine();
            }

            var sum = elements.Sum();
            var average = elements.Average();
            Console.WriteLine($"Sum of elements is: {sum} \nAverage of elements is: {average}");
        }
    }
}
