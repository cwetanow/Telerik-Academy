using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Cube
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort n = ushort.Parse(Console.ReadLine());
            int k = (2 * n - 1);
            char[,] cube = new char[k, k];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    cube[i, j] = ' ';
                }
            }
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    
                    if ((i == 0 && j >= n) || (i == k - 1 && j < n) || (i == n - 1 && j < n) || (i >= n - 1 && j == 0) || (i >= n - 1 && j == n - 1) || (i <= n - 1 && j == k - 1) || (i + j == n - 1) || ((i + j == k - 1) && (i < n)) || (i + j == n - 1) || ((i + j == k +n-2) && (i >= n)))
                    {
                        cube[i, j] = ':';
                    }
                    if (((i + j == n) && (i < n-1)&&i>0))
                    {
                        for (int x = 0; x < n-2; x++)
                        {
                            cube[i, j+x] = '/';
                        }
                    }
                    if ((i + j == k) && (j < k - 1) && j > n-1 )
                    {
                        for (int x = 0; x < n-1 ; x++)
                        {
                            cube[i+x, j] = 'X';
                        }
                    }
                    
                    Console.Write(cube[i,j]);
                }
                Console.WriteLine();
            }

        }
    }
}
