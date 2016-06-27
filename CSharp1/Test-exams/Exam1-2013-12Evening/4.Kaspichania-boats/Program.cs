using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Kaspichania_boats
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] boat = new char[6 + ((n - 3) / 2) * 3, n * 2 + 1];
            for (int i = 0; i < 6 + ((n - 3) / 2) * 3; i++)
            {
                for (int j = 0; j < n * 2 + 1; j++)
                {
                    if (i == n //middle 
                        || j == n //perpendicular
                        || i + j == n //left match
                        || (i == 6 + ((n - 3) / 2) * 3 - 1 && j >= (n / 2 + 1) && j < n * 2 - n / 2) //botton
                        || (j==i+n) //left match
                        || (i==j+n) //left bottom
                        || (i+j==3*n)
                        )
                    {
                        boat[i, j] = '*';
                    }
                    else {
                        boat[i, j] = '.';
                    }
                    Console.Write(boat[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
