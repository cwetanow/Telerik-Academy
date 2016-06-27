using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Matrix_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrixOfThings = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0)
                    {
                        matrixOfThings[i, j] = j+1;
                        Console.Write(matrixOfThings[i, j]+" ");
                    }
                    else {
                        matrixOfThings[i, j] = matrixOfThings[i - 1, j] + 1;
                        Console.Write(matrixOfThings[i,j]+" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
