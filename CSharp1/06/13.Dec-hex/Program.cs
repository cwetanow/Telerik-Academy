using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Dec_hex
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            string hex = "";
            do
            {
                switch (n%16)
                {
                    case 10:
                        hex += "A";
                        break;
                    case 11:
                        hex += "B";
                        break;
                    case 12:
                        hex += "C";
                        break;
                    case 13:
                        hex += "D";
                        break;
                    case 14:
                        hex += "E";
                        break;
                    case 15:
                        hex += "F";
                        break;
                    default:
                        hex += (n % 16).ToString();
                        break;
                }
                n /= 16;
            } while (n!=0);
            char[] badHex = hex.ToArray();
            Array.Reverse(badHex);
            hex = new string(badHex);
            
            Console.WriteLine(hex);
        }
    }
}
