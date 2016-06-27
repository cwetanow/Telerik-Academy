using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.One_system_to_othre
{
    class Program
    {
        static int ConvertOtherDec(char num)
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
                    return 1;

            }
        }
        static long Pow(int num, int deg) {
            if (deg==0)
            {
                return 1;
            }
            else
            {
                return num*Pow(num, deg - 1);
            }
        }
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            string num = Console.ReadLine();
            int d = int.Parse(Console.ReadLine());
            long dec = 0;
            //lvl one
            for (int i = 0; i < num.Length; i++)
            {
                dec += ConvertOtherDec(num[num.Length - 1 - i]) * Pow(s, i);
            }
            //next level
            string result = "";
            do
            {                
                result += ConvertorDecOther(dec,d);
                dec /= d;
            } while (dec != 0);
            //end
            result = string.Join("", result.Reverse().ToArray());
            Console.WriteLine(result);
        }
        static char ConvertorDecOther(long num, int b)
        {
            switch (num % b)
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
                case 15:
                    return 'F';
                default:
                    return 'R';

            }
        }
        

    }
}
