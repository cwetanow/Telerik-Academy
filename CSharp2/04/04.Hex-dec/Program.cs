using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hex_dec
{
    class Program
    {
        static int HexToD(char num)
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
                case'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                default:
                    return 15;

            }
        }
        static void Main(string[] args)
        {
            string hex = Console.ReadLine();
            long dec = 0;
            for (int i = 0; i < hex.Length; i++)
            {
                dec += HexToD(hex[hex.Length - 1 - i]) * (long)Math.Pow(16, i);
            }
            Console.WriteLine(dec);
        }
    }
}
