using System;
using System.Linq;

namespace Diameter
{
    public class Startup
    {
        public const long Inf = 99999;

        public static long[,] FloydWarshall(long[,] graph, int verticesCount)
        {
            var distance = new long[verticesCount, verticesCount];

            for (var i = 0; i < verticesCount; ++i)
            {
                for (var j = 0; j < verticesCount; ++j)
                {
                    distance[i, j] = graph[i, j];
                }
            }

            for (var k = 0; k < verticesCount; ++k)
            {
                for (var i = 0; i < verticesCount; ++i)
                {
                    for (var j = 0; j < verticesCount; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                        }
                    }
                }
            }

            return distance;
        }

        public static long GetLongestPath(long[,] graph, int verticles)
        {
            var distances = FloydWarshall(graph, verticles);

            var max = long.MinValue;

            for (var i = 0; i < verticles; i++)
            {
                for (var j = i + 1; j < verticles; j++)
                {
                    if (distances[i, j] > max)
                    {
                        max = distances[i, j];
                    }
                }
            }

            return max;
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var graph = new long[n, n];

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    graph[i, j] = Inf;
                }
            }

            for (var i = 0; i < n - 1; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(long.Parse)
                    .ToArray();

                graph[input[0], input[1]] = input[2];
                graph[input[1], input[0]] = input[2];
            }

            var longest = GetLongestPath(graph, n);

            Console.WriteLine(longest);
        }

    }
}
