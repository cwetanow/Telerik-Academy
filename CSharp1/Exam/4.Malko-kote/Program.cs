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
            var length = int.Parse(Console.ReadLine());
            var character = Console.ReadLine()[0];
            var width = 9 + (length - 10) / 2;
            var kote = new char[length, width];

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < 9 + (length - 10) / 2; j++)
                {
                    kote[i, j] = ' ';

                    //ears
                    if (i == 0 && (j == 0 || j == width / 2 - 2)) 
                    {
                        kote[i, j] = character;
                    }

                    //head
                    if (i < (length / 4) && i > 0 && j > 0 && j <= width / 2 - 1)
                    {
                        kote[i, j] = character;
                    }

                    if (i < (length / 4) * 2 - 1 && i > 0 && j > 1 && j <= width / 2 - 2) //throat
                    {
                        kote[i, j] = character;
                    }

                    if (i < (length / 4) * 2 - 1 + length / 4 && i >= (length / 4) * 2 - 1 && j > 0 && j <= width / 2 - 1) //traps
                    {
                        kote[i, j] = character;
                    }

                    if (i < length - 1 && i >= (length / 4) * 2 - 1 + length / 4 && j >= 0 && j <= width / 2) //body
                    {
                        kote[i, j] = character;
                    }

                    if (i == length - 1 && j > 0 && j < (length * 3) / 4) //lower
                    {
                        kote[i, j] = character;
                    }

                    if (i == length - 2 && j > width / 2 + 1 && j < (length * 3) / 4) //lower part of tail
                    {
                        kote[i, j] = character;
                    }

                    if (i == length - 2 && j == width / 2 + 2) //tail dot
                    {
                        kote[i, j] = character;
                    }

                    if (i < length - 1 && j == width / 2 + 3 && i >= (length / 4) * 2 + length / 4 - 2)
                    {
                        kote[i, j] = character;
                    }

                    if (i == (length / 4) * 2 + length / 4 - 2 && j > width / 2 + 3)
                    {
                        kote[i, j] = character;
                    }

                    if (j > width / 2 + 2 && (i == length - 1 || i == length - 2))
                    {
                        kote[i, j] = ' ';
                    }

                    if (j == width / 2 + 3 && i == length - 2)
                    {
                        kote[i, j] = character;
                    }

                    Console.Write(kote[i, j]);
                }

                Console.WriteLine();
            }

        }
    }
}
