using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Persian_rugs
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int n = int.Parse(Console.ReadLine());
           int d = int.Parse(Console.ReadLine());
            int rows=2*n+1;
            int cols=2*n+1;

            char[,] rug=new char[rows,cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    rug[i,j]=' ';
                    if ((i+j)==rows-1)//other diagonal
                    {
                        rug[i,j]='/';
                    }
                    if (i==j)//main diagonal
                    {
                        rug[i,j]='\\';

                    }
                    if ((i>j&&(i+j<rows-1)) || 
                        ((j>i)&&(j+i>cols-1))) //left and right side of #
                    {
                        rug[i, j] = '#';
                    }
                    if ((j < n && i + d + 1 == j && i < n) || 
                        ((j > n && j + d + 1 == i && i > n))) // those / of distance
                    {
                        rug[i,j]='\\';
                    }
                    if ((j > n && i + d + 1 + j == cols - 1 && i < n) || 
                        ((j < n && j + i -d== cols && i > n)))// \ of distance
                    {
                        rug[i,j]='/';
                    }
                    if ((j > n && i + d + 1 + j < cols - 1 && i < n) || 
                        ((j < n && j + i -d> cols && i > n))
                        || (j < n && i + d + 1 < j && i < n) ||
                        ((j > n && j + d + 1 < i && i > n)) ||
                        (j==n && ((i<n-d-1)||(i>n+d+1))))
                    {
                        rug[i, j] = '.';
                    }

                    if (i == j && i == n)//center x
                    {
                        rug[i, j] = 'X';
                    }
                    Console.Write(rug[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();


        }
    }
}
