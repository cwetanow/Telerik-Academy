using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01.SecretNumeralSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(',').Select(x => x.Trim()).ToList();
            BigInteger result = 1;

            foreach (var code in input)
            {
                var converted = ConvertToDecimalNumber(code);

                result *= converted;

            }

            Console.WriteLine(result);
        }

        private static BigInteger ConvertToDecimalNumber(string number)
        {
            BigInteger result = 0;

            var numbersEncoded = GetNumbers(number);

            var numbers = ConvertToSevenSystem(numbersEncoded.Select(ConvertToDigit).ToList());

            for (int i = 0; i < numbers.Length; i++)
            {
                result += ConvertOtherDec(numbers[numbers.Length - 1 - i]) * (long)Math.Pow(8, i);
            }

            return result;
        }

        private static string ConvertToSevenSystem(IEnumerable<int> numbers)
        {
            return string.Join("", numbers);
        }

        private static IList<string> GetNumbers(string input)
        {
            var digits = new List<string>()
            {
                 "hristofor",
                 "vladimir",
                 "hristo",
                 "tosho",
                 "pesho",
                 "vlad",
                 "haralampi",
                 "zoro"
            };

            var result = new List<string>();

            while (input.Length > 0)
            {
                var digit = digits.FirstOrDefault(d => input.IndexOf(d, StringComparison.Ordinal) == 0);

                result.Add(digit);
                input = input.Remove(0, digit.Length);
            }

            return result;
        }

        private static int ConvertOtherDec(char num)
        {
            switch (num)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    return -1;

            }
        }

        private static int ConvertToDigit(string input)
        {
            switch (input)
            {
                case "hristo":
                    return 0;
                case "tosho":
                    return 1;
                case "pesho":
                    return 2;
                case "hristofor":
                    return 3;
                case "vlad":
                    return 4;
                case "haralampi":
                    return 5;
                case "zoro":
                    return 6;
                case "vladimir":
                    return 7;
                default:
                    return -1;
            }
        }
    }
}
