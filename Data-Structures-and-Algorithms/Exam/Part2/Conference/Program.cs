using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference
{
    class Program
    {
        private static readonly List<int> counts = new List<int>();
        private static int visitedCount = 0;
        private static bool[] visited;
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var n = input[0];
            var m = input[1];

            graph = new Dictionary<int, List<int>>(n);
            visited = new bool[n];

            for (var i = 0; i < m; i++)
            {
                var couple = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var x = couple[0];
                var y = couple[1];

                if (!graph.ContainsKey(x))
                {
                    graph.Add(x, new List<int>());
                }

                if (!graph.ContainsKey(y))
                {
                    graph.Add(y, new List<int>());
                }

                graph[x].Add(y);
                graph[y].Add(x);
            }

            for (int i = 0; i < n; i++)
            {
                if (!graph.ContainsKey(i))
                {
                    graph.Add(i, new List<int>());
                }
            }

            for (int i = 0; i < n; i++)
            {
                Dfs(i);
                if (visitedCount != 0)
                {
                    counts.Add(visitedCount);
                }

                visitedCount = 0;
            }

            var result = 0l;
            var totalPassed = 0;

            foreach (var company in counts)
            {
                result += company * (n - company - totalPassed);
                totalPassed += company;
            }

            Console.WriteLine(result);
        }

        static void Dfs(int index)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(index);

            while (stack.Count > 0)
            {
                index = stack.Pop();

                if (visited[index])
                {
                    continue;
                }

                visited[index] = true;
                visitedCount++;

                foreach (var i in graph[index])
                {
                    if (!visited[i])
                    {
                        stack.Push(i);
                    }
                }
            }
        }
    }
}