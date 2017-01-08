using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OfficeSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var times = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var tasks = new List<Task>();

            for (int i = 1; i <= n; i++)
            {
                var dependencies = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

                var task = new Task
                {
                    Number = i,
                    Dependencies = dependencies,
                    DuplicateDependencies = new List<int>(dependencies),
                    TimeToComplete = times[i - 1]
                };

                tasks.Add(task);
            }

            if (tasks.All(t => t.Dependencies[0] != 0))
            {
                Console.WriteLine(-1);
                return;
            }

            if (tasks.All(x => x.Dependencies[0] == 0))
            {
                var max = times.Max();
                Console.WriteLine(max);
                return;
            }

            var sortedTasks = CalculateTime(new List<Task>(tasks));

            var taskTime = new Dictionary<int, int>();
            while (sortedTasks.Any())
            {
                var current = sortedTasks.First();
                sortedTasks.RemoveAt(0);

                var time = 0;
                foreach (var dependency in current.DuplicateDependencies)
                {
                    if (dependency != 0)
                    {
                        if (taskTime[dependency] > time)
                        {
                            time = taskTime[dependency];
                        }
                    }
                }

                taskTime.Add(current.Number, time + current.TimeToComplete);
            }

            var maxTime = taskTime.Max(t => t.Value);
            Console.WriteLine(maxTime);
        }

        private static List<Task> CalculateTime(List<Task> tasks)
        {
            var list = new List<Task>();
            var s = tasks
                .Where(t => t.Dependencies.First() == 0)
                .ToList();

            tasks.RemoveAll(t => t.Dependencies.First() == 0);

            while (s.Any())
            {
                var node = s.First();
                s.Remove(node);

                list.Add(node);

                var edges = tasks.Where(t => t.Dependencies.Contains(node.Number)).ToList();
                foreach (var edge in edges)
                {
                    edge.Dependencies.Remove(node.Number);
                    if (!edge.Dependencies.Any())
                    {
                        s.Add(edge);
                        tasks.Remove(edge);
                    }
                }
            }

            return list;
        }
    }

    public class Task
    {
        public int Number { get; set; }

        public List<int> Dependencies { get; set; }

        public List<int> DuplicateDependencies { get; set; }

        public int TimeToComplete { get; set; }
    }
}
