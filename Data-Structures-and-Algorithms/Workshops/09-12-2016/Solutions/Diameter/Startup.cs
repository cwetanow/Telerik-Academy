using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter
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

    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var tree = new List<Edge>();

            for (var i = 0; i < n - 1; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var edge = new Edge(input[0], input[1], input[2]);

                tree.Add(edge);
            }

            tree.Sort();
            
            var result = 0;
            
            Console.WriteLine(result);
        }
    }
}
