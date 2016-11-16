using System;
using System.Collections.Generic;

namespace _02.ReverseIntegers
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter number of elements");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var stack = new Stack<int>();
            for (var i = 0; i < n; i++)
            {
                var element = int.Parse(Console.ReadLine());
                stack.Push(element);
            }

            Console.WriteLine("\nReversed elements:");
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
