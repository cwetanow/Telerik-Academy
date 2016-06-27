using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Malko_kote
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            string k = Console.ReadLine();
            char c = k[0];
            int width=9 + (s - 10) / 2;
            char[,] kote = new char[s, width];
           
           
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < 9 + (s - 10) / 2; j++)
                {

                    kote[i, j] = ' ';
                    if (i==0 && (j==0 || j==width/2-2)) //ears
                    {
                        kote[i, j] = c;
                    }
                    if (i<(s/4) && i>0 && j>0 && j<=width/2-1) //head
                    {
                        kote[i, j] = c;
                    }
                    if (i<(s/4)*2-1 && i>0 && j>1 && j<=width/2-2) //throat
                    {
                        kote[i, j] = c;
                    }
                    if (i<(s/4)*2-1+s/4 && i>=(s/4)*2-1 && j>0 && j<=width/2-1) //traps
                    {
                        kote[i, j] = c;
                    }
                    if (i<s-1 && i>=(s/4)*2-1+s/4 && j>=0 && j<=width/2) //body
                    {
                         kote[i, j] = c;
                    }
                     if (i==s-1 && j>0 && j<(s*3)/4) //lower
                    {
                        kote[i, j] = c;
                    }
                    if (i==s-2 && j>width/2+1 && j<(s*3)/4) //lower part of tail
                    {
                         kote[i, j] = c;
                    }
                    if (i == s-2  &&  j==width/2+2) //tail dot
                    {
                        kote[i, j] = c;
                    }
                    if (i < s-1 && j==width/2+3 && i>=(s/4)*2+s/4-2)
                    {
                        kote[i, j] = c;
                    }
                    if (i == (s/4)*2+s/4-2&& j>width/2+3 )
                    {
                         kote[i, j] = c;
                    }
                    
                    if (j>width/2+2 && (i==s-1 || i==s-2))
                    {
                        kote[i, j] = ' ';
                    }
                    if (j == width / 2 + 3 && i == s - 2)
                    {
                        kote[i, j] = c;
                    }
                    Console.Write(kote[i, j]);
                }
               
                Console.WriteLine();
            }
            
        }
    }
}
