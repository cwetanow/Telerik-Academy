using System;

namespace _01.NestedLoops
{
    public class Startup
    {
        private static int n;
        private static int[] loops;

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            n = int.Parse(Console.ReadLine());
            loops = new int[n];

            Loops(0);
        }

        public static void Loops(int currentLoop)
        {
            if (currentLoop == n)
            {
                PrintLoops();
                return;
            }

            for (var i = 1; i <= n; i++)
            {
                loops[currentLoop] = i;
                Loops(currentLoop + 1);
            }
        }

        public static void PrintLoops()
        {
            Console.WriteLine(string.Join(" ", loops));
        }
    }

}


