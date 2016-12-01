using System;
using System.Linq;

namespace Doge__
{
    class Startup
    {
        static void Print(long[,] table, int rows, int cols)
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    Console.Write(table[i, j] + "    ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var rows = input[0] + 1;
            var cols = input[1] + 1;
            var k = input[2];

            var enemies = Console.ReadLine().Split(';');

            var table = new long[rows, cols];

            foreach (var enemy in enemies)
            {
                var splitted = enemy.Split(' ')
                    .Select(int.Parse)
                    .ToList();

                table[splitted[0], splitted[1]] = -1;
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        table[i, j] = 1;
                        continue;
                    }

                    if (table[i, j] != -1)
                    {
                        if (table[i, j - 1] != -1)
                        {
                            table[i, j] += table[i, j - 1];
                        }

                        if (table[i - 1, j] != -1)
                        {
                            table[i, j] += table[i - 1, j];
                        }
                    }
                }
            }

            Console.WriteLine(table[rows - 1, cols - 1]);
        }
    }
}
