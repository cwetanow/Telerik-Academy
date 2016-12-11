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

            var edges = new List<Edge>();

            InitializeGraph(edges);

            edges.Sort();

            var tree = new int[n + 1];
            var treesCount = 1;

            var mpd = FindMinimumSpanningTree(edges, tree, treesCount);

            var result = 0;

            foreach (var edge in edges)
            {
                if (mpd.Contains(edge))
                {
                    if (!roads[edge.StartNode, edge.EndNode])
                    {
                        var replacement = edges.FirstOrDefault(e => e.StartNode == edge.StartNode && !mpd.Contains(e));

                        if (replacement != null)
                        {
                            result += GetCost(costsToConstruct, replacement.StartNode, replacement.EndNode);
                            continue;
                        }

                        result += GetCost(costsToConstruct, edge.StartNode, edge.EndNode);
                    }
                }
                else
                {
                    if (roads[edge.StartNode, edge.EndNode])
                    {
                        result += GetCost(costsToDestroy, edge.StartNode, edge.EndNode);
                    }
                }
            }

            Console.WriteLine(result);
        }
        private static ICollection<Edge> FindMinimumSpanningTree(IEnumerable<Edge> edges, IList<int> tree, int treesCount)
        {
            var mpd = new List<Edge>();

            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    mpd.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        mpd.Add(edge);
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Count; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }

                        mpd.Add(edge);
                    }
                }
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