using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.English_digit
{
    class Program
    {
        static string EnglishDigit(int num) {
            num %= 10;
            switch (num)
            {
                case 0:
                    return "zero";
                   
                case 1:
                    return "one";
                    
                case 2:
                    return "two";
                    
                case 3:
                    return "three";
                    
                case 4:
                    return "four";
                    
                case 5:
                    return "five";
                    
                case 6:
                    return "six";
                    
                case 7:
                    return "seven";
                    
                case 8:
                    return "eight";
                    
                default:
                    return "nine";
                    
            }
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(EnglishDigit(num));
        }
    }
}
