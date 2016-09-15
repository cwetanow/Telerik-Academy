using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Maximal_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
        .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(item => int.Parse(item))
        .ToArray();
            int n = numbers[0];
            int m = numbers[1];
            int[,] matrix = new int[n, m];
           
            for (int i = 0; i < n; i++)
            {
                int[] lines = Console.ReadLine()
        .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(item => int.Parse(item))
        .ToArray();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = lines[j];
                }
                
            }
            
            int currentMax=-9000;
            int max=-9000;
            for (int i = 1; i < n-1; i++)
            {
                for (int j = 1; j < m-1; j++)
                {
                    currentMax=matrix[i-1,j-1]+matrix[i,j-1]+matrix[i+1,j-1]
                        +matrix[i-1,j]+matrix[i,j]+matrix[i+1,j]
                        +matrix[i-1,j+1]+matrix[i,j+1]+matrix[i+1,j+1];
                    if (currentMax>max)
                    {
                        max = currentMax;
                    }
                }
            }
            Console.WriteLine(max);
            
        }
    }
}
