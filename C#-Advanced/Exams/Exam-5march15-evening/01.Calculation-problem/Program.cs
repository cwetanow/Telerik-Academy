using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Calculation_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = Console.ReadLine().Split(' ');
            var sum = 0;
            foreach (var word in strings)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    sum += (word[i]-'a')*(int)Math.Pow(23,word.Length - i-1);
                }
            }
            var sumToCOnvert=sum;
            var result = new StringBuilder();
             do
	        {
                result.Append((char)(sumToCOnvert%23+97));
                sumToCOnvert /= 23;
	        } while (sumToCOnvert!=0);
            
             Console.WriteLine("{0} = {1}", Reverse(result.ToString()),sum);
         }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        
    }
}
