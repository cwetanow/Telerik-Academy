using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Nightmare_on_code_street
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int digits = 0;
            long sum = 0;
            for (int i = 1; i < input.Length; i+=2)
            {
                
                if (char.IsDigit(input[i]))
                {
                    digits++;
                    sum += input[i] - '0';
                }
                
                
                
            }
            Console.Write("{0} {1}",digits,sum);
        }
    }
}
