using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guards
{
    class Program
    {
        static void Main(string[] args)
        {
            var coords = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rows = coords[0];
            var cols = coords[1];

            var guardsCount = int.Parse(Console.ReadLine());

            var maze = new long[rows, cols];

            for (var i = 0; i < guardsCount; i++)
            {
                var guardCoords = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                var x = int.Parse(guardCoords[0]);
                var y = int.Parse(guardCoords[1]);
                var direction = guardCoords[2];

                maze[x, y] = -1;

                try
                {
                    if (direction == "D")
                    {
                        if (maze[x + 1, y] == 0)
                        {
                            maze[x + 1, y] = 3;
                        }
                    }
                    else if (direction == "U")
                    {
                        if (maze[x - 1, y] == 0)
                        {
                            maze[x - 1, y] = 3;
                        }
                    }
                    else if (direction == "L")
                    {
                        if (maze[x, y - 1] == 0)
                        {
                            maze[x, y - 1] = 3;
                        }
                    }
                    else
                    {
                        if (maze[x, y + 1] == 0)
                        {
                            maze[x, y + 1] = 3;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            maze[0, 0] = 1;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (maze[i, j] != -1)
                    {
                        if ((i == 0 || maze[i - 1, j] == -1) && (j == 0 || maze[i, j - 1] == -1))
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }

                            maze[i, j] = -1;
                            continue;
                        }

                        if (maze[i, j] == 0)
                        {
                            maze[i, j] = 1;
                        }

                        var current = maze[i, j];

                        var top = long.MaxValue;
                        if (i > 0 && maze[i - 1, j] != -1)
                        {
                            top = maze[i - 1, j];
                        }

                        var left = long.MaxValue;
                        if (j > 0 && maze[i, j - 1] != -1)
                        {
                            left = maze[i, j - 1];
                        }

                        if (left != int.MaxValue || top != int.MaxValue)
                        {
                            current += Math.Min(top, left);
                        }

                        maze[i, j] = current;
                    }
                }
            }

            var result = maze[rows - 1, cols - 1];
            if (result == -1)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
