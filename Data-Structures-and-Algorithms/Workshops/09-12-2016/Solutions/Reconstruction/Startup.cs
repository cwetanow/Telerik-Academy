using System;
using System.Collections.Generic;
using System.Linq;

namespace Reconstruction
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            var weightCompared = this.Weight.CompareTo(other.Weight);
            return weightCompared == 0 ? this.StartNode.CompareTo(other.StartNode) : -weightCompared;
        }
    }
    public class Startup
    {
        private static bool[,] roads;
        private static int n;
        private static char[,] costsToConstruct;
        private static char[,] costsToDestroy;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            roads = new bool[n, n];

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                for (var j = 0; j < n; j++)
                {
                    var hasRoad = input[j] == '1';
                    roads[i, j] = hasRoad;
                }
            }

            costsToConstruct = new char[n, n];
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                for (var j = 0; j < n; j++)
                {
                    costsToConstruct[i, j] = input[j];
                }
            }

            costsToDestroy = new char[n, n];
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                for (var j = 0; j < n; j++)
                {
                    costsToDestroy[i, j] = input[j];
                }
            }

            var initialEdges = GetInitialEdges();

            var edges = new List<Edge>();

            InitializeGraph(edges);

            var mpd = FindMinimumSpanningTree(new List<Edge>(edges), n);

            var result = 0;

            foreach (var initialEdge in initialEdges)
            {
                if (mpd.FirstOrDefault(e => e.StartNode == initialEdge.StartNode && e.EndNode == initialEdge.EndNode) == null)
                {
                    var edge = mpd.FirstOrDefault(x => x.StartNode == initialEdge.StartNode);

                    result += GetCost(costsToDestroy, edge.StartNode, edge.EndNode);
                }
            }

            foreach (var edge in mpd)
            {
                if (initialEdges.FirstOrDefault(x => x.StartNode == edge.StartNode && x.EndNode == edge.EndNode) == null)
                {
                    result += GetCost(costsToConstruct, edge.StartNode, edge.EndNode);
                }
            }

            Console.WriteLine(result);
        }

        private static IList<Edge> GetInitialEdges()
        {
            var result = new List<Edge>();

            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (roads[i, j])
                    {
                        result.Add(new Edge(i, j, 0));
                    }
                }
            }

            return result;
        }

        private static ICollection<Edge> FindMinimumSpanningTree(List<Edge> edges, int vertexCount)
        {
            var mpd = new List<Edge>();

            var startEdge = edges.OrderBy(e => e.Weight).FirstOrDefault();
            mpd.Add(startEdge);
            edges.Remove(startEdge);

            while (mpd.Count < vertexCount - 1)
            {
                var allVertex = mpd.Select(x => x.StartNode).ToList();
                allVertex.AddRange(mpd.Select(x => x.EndNode));
                allVertex = allVertex.Distinct().ToList();

                var candidate = edges.Where(x => allVertex.Contains(x.StartNode) || allVertex.Contains(x.EndNode))
                    .OrderBy(x => x.Weight)
                    .FirstOrDefault();

                mpd.Add(candidate);
                edges.Remove(candidate);
            }

            return mpd;
        }

        private static void InitializeGraph(ICollection<Edge> edges)
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (roads[i, j])
                    {
                        var weight = GetCost(costsToDestroy, i, j);
                        edges.Add(new Edge(i, j, weight));
                    }
                    else
                    {
                        var weight = GetCost(costsToConstruct, i, j);
                        edges.Add(new Edge(i, j, weight));
                    }
                }
            }
        }


        public static int GetCost(char[,] costs, int i, int j)
        {
            return costs[i, j] > 96 ? costs[i, j] - 71 : costs[i, j] - 65;
        }
    }
}