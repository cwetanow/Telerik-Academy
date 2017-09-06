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
            if (IsPalindrome(str))
            {
                return 0;
            }

            return 1 + CountNumberOfAppends(str.Substring(1, str.Length - 1));
        }

        static bool IsPalindrome(string str)
        {
            var lenght = str.Length;

            if (lenght == 1)
            {
                return true;
            }

            for (int i = 0, j = lenght - 1; i < j; i++, j--)
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
