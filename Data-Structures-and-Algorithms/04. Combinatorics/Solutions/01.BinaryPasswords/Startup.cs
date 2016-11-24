using System;

namespace _01.BinaryPasswords
{
    class Startup
    {
        static void Main(string[] args)
        {
            var template = Console.ReadLine();

            var passwordsCount = CalculateDifferentPasswords(template);

            Console.WriteLine(passwordsCount);
        }

        private static long CalculateDifferentPasswords(string template)
        {
            var result = 1L;

            foreach (var t in template)
            {
                if (t == '*')
                {
                    result *= 2;
                }
            }

            return result;
        }
    }
}
