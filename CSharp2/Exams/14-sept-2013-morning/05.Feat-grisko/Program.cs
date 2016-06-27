using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Feat_grisko
{
    
    class Program
    {
        static int Factorial(int n) {
            if (n==1)
            {
                return 1;
            }
            else
            {
                return n*Factorial(n - 1);
            }
        }
        static int FindMaxLetterPovtorations(string input, char[] alphabet, bool[] haveBukva){
            int max = 0;
            int count = 0;
            for (int i = 0; i < 26; i++)
            {
                count = 0;
                if (haveBukva[i])
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (alphabet[i]==input[j])
                        {
                            count++;
                        }
                    }
                }
                if (max<count)
                {
                    max = count;
                }
            }
            //Console.WriteLine(max);
            return max;
        }
        
        static int FindVariations(string input, int count, int length)
        {
            int n = input.Length;
            if ((n / 2 < length && input.Length % 2 == 0) || ((n / 2 +1< length && n % 2 == 1)))
            {
                return 0;
            }
            else if (count==n)
            {
                return Factorial(count);
            }
            else if (count==2 && (length==n/2 || length==n/2+1))
            {
                return 1;
            }
            else 
            {
                return Factorial(n)-count*n;
            }
            
            
            
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var count = 0;
            char[] alphabet = new char[26];
            for (int i = 0; i < 26; i++)
            {
                alphabet[i]=(char)(97+i);
            }
            bool[] isHere=new bool[26];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (input[i]==alphabet[j] && !isHere[j])
                    {
                        isHere[j] = true;
                        count++;
                    }
                }
            }
            int length = FindMaxLetterPovtorations(input,alphabet,isHere);
            Console.WriteLine(FindVariations(input,count,length));
        }
    }
}
