using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Text_to_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            text=text.ToLower();
            long result = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (currentChar == '@') {
                    break;
                }
                if (char.IsDigit(currentChar)) { 
                    result*=(currentChar -'0');
                }
                else if ((currentChar >= 65 && currentChar <= 90) || (currentChar >= 97 && currentChar <= 122))
                {
                    result += (currentChar - 'a');
                }
                else {
                    result %= m;
                }
                    


                
            }
            Console.WriteLine(result);
        }
    }
}
