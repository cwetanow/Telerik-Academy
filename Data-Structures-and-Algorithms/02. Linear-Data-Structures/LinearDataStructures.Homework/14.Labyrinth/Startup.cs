using System;

namespace _14.Labyrinth
{
    public class Startup
    {
        private static readonly string[,] matrix =
            {
                {"0","0","0","x","0","x" },
                {"0","x","0","x","0","x" },
                {"0","*","x","0","x","0" },
                {"0","x","0","0","0","0" },
                {"0","0","0","x","x","0" },
                {"0","0","0","x","0","x" }

            };

        private static bool[,] visited;

        private static int index = 1;

        public static void Main(string[] args)
        {
            visited = new bool[6, 6];
            Print();
            Fill(2, 1);
            Fill();
            Console.WriteLine();
            Print();
        }

        public static void Fill()
        {
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        matrix[i, j] = "u";
                    }
                }
            }
        }

        public static void Fill(int x, int y)
        {
            if (matrix[x, y] != "0" &&
                matrix[x, y] != "x" &&
                matrix[x, y] != "*")
            {
                index = int.Parse(matrix[x, y]) + 1;
            }

            try
            {
                if (matrix[x + 1, y] == "0")
                {
                    matrix[x + 1, y] = index.ToString();
                }
            }
            catch
            {
                // ignored
            }

            try
            {
                if (matrix[x - 1, y] == "0")
                {
                    matrix[x - 1, y] = index.ToString();

                }
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                if (matrix[x, y + 1] == "0")
                {
                    matrix[x, y + 1] = index.ToString();

                }
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                if (matrix[x, y - 1] == "0")
                {
                    matrix[x, y - 1] = index.ToString();

                }
            }
            catch (Exception)
            {
                // ignored
            }

            visited[x, y] = true;
            index++;

            try
            {
                if (matrix[x + 1, y] != "x" && !visited[x + 1, y])
                {
                    Fill(x + 1, y);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                if (matrix[x - 1, y] != "x" && !visited[x - 1, y])
                {
                    Fill(x - 1, y);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                if (matrix[x, y + 1] != "x" && !visited[x, y + 1])
                {
                    Fill(x, y + 1);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                if (matrix[x, y - 1] != "x" && !visited[x, y + 1])
                {
                    Fill(x, y - 1);
                }
            }
            catch (Exception)
            {
                // ignored
            }

        }
        public static void Print()
        {
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
            }
        }
    }
}
