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
            return weightCompared == 0 ? this.StartNode.CompareTo(other.StartNode) : weightCompared;
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

            var edges = new List<Edge>();

            InitializeGraph(edges);

            var tree = new int[n + 1];

            var mpd = FindMinimumSpanningTree(edges, tree, 1, n);

            var result = 0;

            foreach (var edge in edges)
            {
                if (mpd.Contains(edge))
                {
                    if (!roads[edge.StartNode, edge.EndNode])
                    {
                        result += GetCost(costsToConstruct, edge.StartNode, edge.EndNode);
                    }
                }
                else
                {
                    // HAVE TO FIND BEST FUCKING OPTIMAL NODE TO DESTROY 
                    if (roads[edge.StartNode, edge.EndNode])
                    {
                        var connectedNodes = edges.Where(e => EdgeIsConnected(edge, e))
                            .ToList();

                        connectedNodes.Remove(edge);

                        if (connectedNodes.Count > 0)
                        {
                            var littlest = connectedNodes
                                .OrderBy(x => x.Weight)
                                .FirstOrDefault();

                            if (roads[littlest.StartNode, littlest.EndNode])
                            {
                                result += GetCost(costsToDestroy, littlest.StartNode, littlest.EndNode);
                            }

                            continue;
                        }

                        result += GetCost(costsToDestroy, edge.StartNode, edge.EndNode);
                    }
                }
            }

            Console.WriteLine(result);
        }

        private static bool EdgeIsConnected(Edge edge, Edge comparingEdge)
        {
            return edge.StartNode == comparingEdge.StartNode ||
                   edge.StartNode == comparingEdge.EndNode ||
                   edge.EndNode == comparingEdge.StartNode ||
                   edge.EndNode == comparingEdge.EndNode;
        }

        private static ICollection<Edge> FindMinimumSpanningTree(IList<Edge> edges, IList<int> tree, int treesCount, int nodesCount)
        {
            var mpd = new List<Edge>();

            edges = edges.OrderBy(x => x.Weight).ToList();
            var addedEdges = new List<int>();

            var starter = edges.FirstOrDefault();

            if (starter == null)
            {
                return mpd;
            }
            mpd.Add(starter);
            addedEdges.Add(starter.StartNode);
            addedEdges.Add(starter.EndNode);

            while (mpd.Count != nodesCount - 1)
            {
                var minimal = edges.FirstOrDefault(e => AddedEdgesContainsEdge(addedEdges, e));

                if (minimal != null)
                {
                    mpd.Add(minimal);
                    addedEdges.Add(addedEdges.Contains(minimal.StartNode) ? minimal.EndNode : minimal.StartNode);
                    edges.Remove(minimal);
                }
            }

            return mpd;
        }

        private static bool AddedEdgesContainsEdge(ICollection<int> addedEdges, Edge edge)
        {
            var startIsIn = addedEdges.Contains(edge.StartNode);
            var endIsIn = addedEdges.Contains(edge.EndNode);

            return (startIsIn && !endIsIn) || (!startIsIn && endIsIn);
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
