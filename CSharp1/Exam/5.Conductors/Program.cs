using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Conductors
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string p= Convert.ToString(int.Parse(Console.ReadLine()),2);
            int m = int.Parse(Console.ReadLine());
            int[] numbers = new int[m];
            string[] numberos = new string[m];
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < m; i++)
            {
                numberos[i] = Convert.ToString(int.Parse(Console.ReadLine()),2);
                Console.WriteLine(numberos[i]);
             }
            for (int i = 0; i < m; i++)
            {
                for (int j = p.Length-1; j >=0; j++)
                {
                    if (numberos[i][j]==p[j])
                    {
                        sb[i][j] = '0';
                    }
                }
            }
            

        }
    }
}
