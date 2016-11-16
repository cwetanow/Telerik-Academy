using System;
using System.Collections.Generic;

namespace _05.RemoveNegativeNumbers
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, -5, -222, 425, -213, 213, 213123, -125 };

            var positiveNumbers = RemoveNegativeNumbers(list);

            foreach (var positiveNumber in positiveNumbers)
            {
                Console.WriteLine(positiveNumber);
            }
        }

        public static List<int> RemoveNegativeNumbers(List<int> list)
        {
            var count = list.Count;

            for (var i = 0; i < count; i++)
            {
                if (list[i] < 0)
                {
                    list.RemoveAt(i);
                    i--;
                    count--;
                }
            }

            return list;
        }
    }
}
