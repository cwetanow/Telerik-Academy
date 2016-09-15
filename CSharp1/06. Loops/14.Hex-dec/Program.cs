using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Hex_dec
{
    class Program
    {
        static void Main(string[] args)
        {
            string hex = Console.ReadLine();
            long numberInDec = 0;
            for (int i = hex.Length-1; i >=0; i--)
            {
                switch (hex[i])
                {
                    case 'F':
                        numberInDec += 15 * (long)(Math.Pow(16, hex.Length - 1 - i));
                        break;
                    case 'A':
                        numberInDec += 10 * (long)(Math.Pow(16, hex.Length - 1 - i));
                        break;
                    case 'B':
                        numberInDec += 11 * (long)(Math.Pow(16, hex.Length - 1 - i));
                        break;
                    case 'C':
                        numberInDec += 12 * (long)(Math.Pow(16, hex.Length - 1 - i));
                        break;
                    case 'D':
                        numberInDec += 13 * (long)(Math.Pow(16, hex.Length - 1 - i));
                        break;
                    case 'E':
                        numberInDec += 14 * (long)(Math.Pow(16, hex.Length - 1 - i));
                        break;
                    default:
                        numberInDec += int.Parse(hex[i].ToString()) * (long)(Math.Pow(16, hex.Length - 1 - i));
                        break;
                }
            }
            Console.WriteLine(numberInDec);
        }
    }
}
