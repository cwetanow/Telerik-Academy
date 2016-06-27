using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Enter_numbers
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
                
            }
            bool isTrue = true;
            
            for (int i = 1; i < 10; i++)
            {
                
                if (numbers[i-1]>=numbers[i])
                {
                    isTrue = false;
                    break;
                }
                else if (numbers[i]<0 || numbers[i]>100)
                {
                    isTrue = false;
                    break;
                }
                else if (numbers[0] < 0 || numbers[0] > 100)
                {
                    isTrue = false; break;

                }
            }
            if (!isTrue)
            {
                Console.WriteLine("Exception");
            }
            else
            {
                Console.Write("1 <");
                for (int i = 0; i < 10; i++)
                {                  
                    Console.Write(" {0} <",numbers[i]);                   
                 }
                Console.Write(" 100");
            }
        }

    }
}
