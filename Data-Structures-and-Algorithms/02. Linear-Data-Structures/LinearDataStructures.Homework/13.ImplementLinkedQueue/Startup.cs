using System;

namespace _13.ImplementLinkedQueue
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var queue = new LinkedQueue<int>();

            for (var i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
