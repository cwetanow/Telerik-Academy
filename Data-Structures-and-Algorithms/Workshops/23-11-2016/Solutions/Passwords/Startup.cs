using System;
using System.Collections.Generic;

namespace Passwords
{
    public class Startup
    {
        private static readonly List<string> Passwords = new List<string>();

        private static int n;
        private static int k;
        private static string relations;

        private static readonly char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            relations = Console.ReadLine();
            k = int.Parse(Console.ReadLine());

            var result = new char[n];

            foreach (var number in numbers)
            {
                result[0] = number;
                Generate(result, 1);
            }

            Passwords.Sort();
            Console.WriteLine(Passwords[k - 1]);
        }

        public static void Generate(char[] result, int index)
        {
            while (true)
            {
                if (index >= n)
                {
                    Passwords.Add(string.Join("", result));
                }
                else
                {
                    if (relations[index - 1] == '>')
                    {
                        if (result[index - 1] != '0')
                        {
                            var lastNum = result[index - 1] - '0';
                            for (var i = lastNum + 1; i < 11; i++)
                            {
                                result[index] = numbers[i - 1];
                                Generate(result, index + 1);
                            }
                        }
                    }
                    else if (relations[index - 1] == '<')
                    {
                        if (result[index - 1] != '1')
                        {
                            var lastNum = result[index - 1] - '0';
                            lastNum = lastNum == 0 ? 10 : lastNum;

                            for (var i = 1; i < lastNum; i++)
                            {
                                result[index] = numbers[i - 1];
                                Generate(result, index + 1);
                            }
                        }
                    }
                    else
                    {
                        result[index] = result[index - 1];
                        index = index + 1;

                        continue;
                    }
                }

                break;
            }
        }
    }
}
