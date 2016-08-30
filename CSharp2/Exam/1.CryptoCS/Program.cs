using System;
using System.Text;
using System.Numerics;
namespace _1.CryptoCS
{
    class Program
    {
        static int GetNumInTwentySix(char letter)
        {
            return letter - 'a';
        }

        static BigInteger TwentySixtoDecimal(string twentysix)
        {
            BigInteger result = 0;

            for (int i = 0; i < twentysix.Length; i++)
            {
                var num = GetNumInTwentySix(twentysix[i]);
                result += (num * BigInteger.Pow(26, twentysix.Length - i - 1));
            }

            return result;
        }

        static BigInteger SeventoDecimal(string seven)
        {
            BigInteger result = 0;

            for (int i = 0; i < seven.Length; i++)
            {
                var digit = (byte)(seven[i] - '0');
                result += (digit * BigInteger.Pow(7, seven.Length - i - 1));
            }

            return result;
        }

        static string Reverse(string input)
        {
            var result = new StringBuilder();

            for (int i = input.Length - 1; i > -1; i--)
            {
                result.Append(input[i]);
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            var first = Console.ReadLine();
            var sign = Console.ReadLine();
            var second = Console.ReadLine();

            var a = TwentySixtoDecimal(first);
            var b = SeventoDecimal(second);

            BigInteger sum;

            switch (sign)
            {
                case "+":
                    sum = a + b;
                    break;
                default:
                    sum = a - b;
                    break;
            }

            var reversed = new StringBuilder();

            do
            {
                reversed.Append(sum % 9);
                sum /= 9;
            } while (sum != 0);

            var result = Reverse(reversed.ToString());
            Console.WriteLine(result);
        }
    }
}