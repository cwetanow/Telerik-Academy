using System;
using System.Collections.Generic;

namespace _03.SortElements
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

            elements.Sort();

            Console.WriteLine("Sorted elements");
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }
    }
}
