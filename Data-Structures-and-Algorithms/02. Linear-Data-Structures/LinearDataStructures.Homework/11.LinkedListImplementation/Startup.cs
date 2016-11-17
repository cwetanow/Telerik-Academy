using System;

namespace _11.LinkedListImplementation
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            Console.WriteLine("Contains 3? -> " + list.Contains(3));

            Console.WriteLine(list);
        }
    }
}
