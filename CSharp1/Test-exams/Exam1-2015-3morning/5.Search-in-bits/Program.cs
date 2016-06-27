using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Search_in_bits
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int s = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            long[] numbers = new long[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }
            string numberToCompare = Convert.ToString(s, 2).PadLeft(4,'0');
            
            string currentNumber;
            
            int counter = 0;
            
            
            for (int j = 0; j < n; j++)
            {
                
                currentNumber = Convert.ToString(numbers[j], 2).PadLeft(30, '0');
                
                for (int i = 29; i > 2; i--)
                {

                    if (numberToCompare[3] == currentNumber[i] && numberToCompare[2] == currentNumber[i - 1] &&
                        numberToCompare[1] == currentNumber[i - 2] && numberToCompare[0] == currentNumber[i - 3])
                    {

                        counter++;
                    }  
                }
            }

        
            Console.WriteLine(counter);

        }
    }
}
