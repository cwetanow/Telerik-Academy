using System;

namespace OddNumber
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var res = 0L;

            for (var i = 0; i < n; i++)
            {
                res = res ^ long.Parse(Console.ReadLine());
            }

            Console.WriteLine(res);
        }

    }
}