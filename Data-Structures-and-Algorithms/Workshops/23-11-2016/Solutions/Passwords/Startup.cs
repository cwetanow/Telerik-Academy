using System;
using System.Collections.Generic;
using System.Text;

namespace Passwords
{
    public class Startup
    {
        private static readonly List<string> Passwords = new List<string>();
        private static int n;
        private static int k;
        private static string relations;
        private static readonly int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            relations = Console.ReadLine();
            k = int.Parse(Console.ReadLine());

            foreach (var number in numbers)
            {
                Generate(number.ToString());
            }

            Passwords.Sort();
            Console.WriteLine(Passwords[k - 1]);
        }

        public static void Generate(string result)
        {
            var index = result.Length;
            if (index >= n)
            {
                if (!Passwords.Contains(result))
                {
                    Passwords.Add(result);
                }

                return;
            }

            var sign = relations[index - 1];

            if (sign == '=')
            {
                Generate(result + numbers[index]);
            }
            else if (sign == '<')
            {
                var lastNum = result[index - 1] - '0';
                lastNum = lastNum == 0 ? 10 : lastNum;
                if (lastNum == 1)
                {
                    return;
                }

                for (var i = 1; i < lastNum; i++)
                {
                    Generate(result + numbers[i - 1]);
                }
            }
            else if (sign == '>')
            {
                var lastNum = result[index - 1] - '0';
                if (lastNum == 0)
                {
                    return;
                }

                for (var i = lastNum + 1; i < 11; i++)
                {
                    Generate(result + numbers[i - 1]);
                }
            }
        }
    }
}
