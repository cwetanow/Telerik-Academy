using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern
{
    public class Startup
    {
        private const string First = "urd";
        private static List<char> Directions;

        public static void Main(string[] args)
        {
            Directions = new List<char>() { 'l', 'u', 'r', 'd' };
            var n = int.Parse(Console.ReadLine());

            var previous = First;

            for (var i = 1; i < n; i++)
            {
                var builder = new StringBuilder();

                foreach (var ch in previous)
                {
                    if (ch == 'u' || ch == 'd')
                    {
                        builder.Append(GetNext(ch));
                    }
                    else
                    {
                        builder.Append(GetPrevious(ch));
                    }
                }

                builder.Append('u');

                builder.Append(previous);
                builder.Append('r');
                builder.Append(previous);

                builder.Append('d');
                foreach (var ch in previous)
                {
                    if (ch == 'u' || ch == 'd')
                    {
                        builder.Append(GetPrevious(ch));
                    }
                    else
                    {
                        builder.Append(GetNext(ch));
                    }
                }

                previous = builder.ToString();
            }

            Console.WriteLine(previous);
        }

        public static char GetPrevious(char dir)
        {
            var index = (Directions.IndexOf(dir) - 1) < 0 ? 3 : Directions.IndexOf(dir) - 1;
            return Directions[index];
        }

        public static char GetNext(char dir)
        {
            var index = (Directions.IndexOf(dir) + 1) > 3 ? 0 : Directions.IndexOf(dir) + 1;
            return Directions[index];
        }
    }
}
