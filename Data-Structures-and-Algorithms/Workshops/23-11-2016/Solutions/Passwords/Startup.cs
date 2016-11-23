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
            while (true)
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

                if (relations[index - 1] == '=')
                {
                    result = result + result[index - 1];
                    continue;
                }
                else if (relations[index - 1] == '<')
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
                else if (relations[index - 1] == '>')
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
                break;
            }
        }
    }
}
