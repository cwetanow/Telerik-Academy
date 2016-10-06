using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Bin_hex
{
    class Program
    {
        static void Main(string[] args)
        {
            string binary = Console.ReadLine();

            long dec = 0;
            for (int i = 0; i < binary.Length; i++)
            {

                dec += ((binary[binary.Length - i - 1] - '0') * (long)Math.Pow(2, i));


            }
            string hex = "";
            do
            {
                hex += Hex(dec);
                dec /= 16;
            } while (dec != 0);
            hex = string.Join("", hex.Reverse().ToArray());

            Console.WriteLine(hex);
        }
        static char Hex(long num)
        {
            switch (num % 16)
            {
                case 0:
                    return '0';
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                case 5:
                    return '5';
                case 6:
                    return '6';
                case 7:
                    return '7';
                case 8:
                    return '8';
                case 9:
                    return '9';
                case 10:
                    return 'A';
                case 11:
                    return 'B';
                case 12:
                    return 'C';
                case 13:
                    return 'D';
                case 14:
                    return 'E';


                default:
                    return 'F';

            }
        }
    }
}
