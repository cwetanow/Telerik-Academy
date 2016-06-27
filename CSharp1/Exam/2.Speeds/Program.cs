using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Speeds
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int c = int.Parse(Console.ReadLine());
            int[] s = new int[c];
            
            for (int i = 0; i < c; i++)
            {
                s[i] = int.Parse(Console.ReadLine());
            }
            
            int maxGroup = 1;
            int currentMaxGroup = 1;
            int maxSum = 0;
            int currentMaxSum = 0;
            int currentCar=s[0];
           
            for (int i = 0; i < c; i++)
            {
               // Console.WriteLine("the selecdet {0}, current is {1}", currentCar, s[i]);
               
                
                if (currentCar>=s[i])
                {
                    
                    currentMaxGroup=1;
                    currentMaxSum = s[i];
                    currentCar = s[i];
                  
                    
                }
                else
                {
                    currentMaxGroup++;
                    currentMaxSum += s[i];
                    
                    if (currentMaxGroup>=maxGroup)
                    {
                        maxGroup = currentMaxGroup;                       
                        
                       //Console.WriteLine(i);
                       // Console.WriteLine(maxGroup);
                        if (maxSum <= currentMaxSum)
                        {
                            maxSum = currentMaxSum;
                        }
                        
                    }
                   
                    
                    
                }
               // Console.WriteLine("the current max {0}", currentMaxSum);
                
               //Console.WriteLine("max {0}", maxSum);
               //Console.WriteLine();
            }
            
            if (maxGroup==1)
            {
                for (int i = 0; i < c; i++)
                {
                    if (maxSum<s[i])
                    {
                        maxSum = s[i];
                    }
                }
            }
          // Console.WriteLine(maxGroup);
            Console.WriteLine(maxSum);

        }
    }
}
