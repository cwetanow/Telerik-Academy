using System;

namespace _6.WoodenBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = CountNumberOfAppends(input);

            Console.WriteLine(result);
        }

        public static int CountNumberOfAppends(string str)
        {
            var result = 0;
            var index = 0;
            while (!IsPalindrome(str, index))
            {
                index++;
                result++;
            }

            return result;
        }

        static bool IsPalindrome(string str, int start)
        {
            var lenght = str.Length;

            if (lenght == 1)
            {
                return true;
            }

            for (int i = start, j = lenght - 1; i < j; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
