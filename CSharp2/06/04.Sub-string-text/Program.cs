using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sub_string_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine().ToLower(); 
            string text = Console.ReadLine().ToLower();
           // Console.WriteLine(text);
            int count=0;
            bool isTrue = true;
            for (int i = 0; i < text.Length-pattern.Length+1; i++)
            {
                isTrue = true;
                if (text[i]==pattern[0])
                {
                    for (int j = 0; j < pattern.Length; j++)
                    {
                        if (text[i+j]!=pattern[j])
                        {
                            isTrue = false;
                        }
                    }
                    if (isTrue)
                    {
                        count++;
                      //  i += pattern.Length;
                    }
                }
               // Console.WriteLine("{0}-{1}",i,count);
                
            }
            Console.WriteLine(count);
        }
    }
}
