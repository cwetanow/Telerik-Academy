using System;
using System.Linq;
using System.Text;

namespace Documentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = RemoveWhitespace(Console.ReadLine());

            var len = str.Length;
            var steps = 0;
            for (var i = 0; i < len / 2; i++)
            {
                var left = str[i];
                var right = str[len - 1 - i];

                if (left > 95)
                {
                    left = (char)(left - 32);
                }

                if (right > 95)
                {
                    right = (char)(right - 32);
                }

                if (left == right)
                {
                    continue;
                }

                var distance = Math.Abs(left - right);
                if (distance > 13)
                {
                    distance = 26 - distance;
                }

                steps += distance;
            }

            Console.WriteLine(steps);
        }

        private static string RemoveWhitespace(string str)
        {
            var builder = new StringBuilder();
            foreach (var charche in str)
            {
                if (char.IsLetter(charche))
                {
                    builder.Append(charche);
                }
            }

            return builder.ToString();
        }
    }
}
