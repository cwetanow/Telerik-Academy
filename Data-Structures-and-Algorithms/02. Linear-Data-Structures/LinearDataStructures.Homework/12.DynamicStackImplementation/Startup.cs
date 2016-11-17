using System;

namespace _12.DynamicStackImplementation
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var stack = new DynamicStack<int>();

            for (var i = 0; i < 10; i++)
            {
                stack.Push(i);

                Console.WriteLine(stack.Pop());
            }
        }
    }
}
