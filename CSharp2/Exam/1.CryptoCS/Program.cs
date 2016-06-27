using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _1.CryptoCS
{
    class Program
    {
        static BigInteger Pow(int num, int deg)
        {
            BigInteger result = 1;
            for (int i = 0; i < deg; i++)
            {
                result *= num;
            }
            return result;
        }
        static int GetNum26(char letter)
        {
            return letter - 'a';
        }
        static BigInteger TStoDec(string twentysix)
        {
            BigInteger result = 0;
            int num;
            for (int i = 0; i < twentysix.Length; i++)
            {
                num=GetNum26(twentysix[i]);
                result += (num* Pow(26, twentysix.Length - i - 1));
            }
            return result;
        }
        static BigInteger StoDec(string seven)
        {
            BigInteger result = 0;
            byte digit;
            for (int i = 0; i < seven.Length; i++)
            {
                digit = (byte)(seven[i] - '0');
                result += (digit * Pow(7, seven.Length - i - 1));
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
            var a = TStoDec(first);
            var b = StoDec(second);
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
            var result = new StringBuilder();
            do
            {
                result.Append(sum%9);

                sum /= 9;
            } while (sum != 0);

            Console.WriteLine(Reverse(result.ToString()));
        }
    }
}