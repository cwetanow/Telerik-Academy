using System;
using System.Collections.Generic;

namespace _10.SortedOperators
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var start = 5; // int.Parse(Console.ReadLine());
            var end = 16; // int.Parse(Console.ReadLine());

            var sequence = ShortestSequenceOfOperations(end, start);

            Console.WriteLine(sequence);
        }

        private static string ShortestSequenceOfOperations(int end, int start)
        {
            var list = new List<int> { end };

            while (end > start)
            {
                if (end / 2 >= start)
                {
                    if (end % 2 == 1)
                    {
                        end--;
                        list.Add(end);
                    }

                    end /= 2;
                    list.Add(end);
                }
                else if (end - 2 >= start)
                {
                    end -= 2;
                    list.Add(end);
                }
                else
                {
                    end--;
                    list.Add(end);
                }
            }

            list.Sort();

            return string.Join(", ", list);
        }
    }
}
