using System;
using System.Collections.Generic;

namespace _09.FirstNumbersOfSequence
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<int>();

            var n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            queue.Enqueue(n);

            for (var i = 0; i < 50; i++)
            {
                Console.WriteLine(queue.Peek());

                var s = queue.Dequeue();

                queue.Enqueue(s + 1);
                queue.Enqueue(2 * s + 1);
                queue.Enqueue(s + 2);
            }
        }
    }
}
