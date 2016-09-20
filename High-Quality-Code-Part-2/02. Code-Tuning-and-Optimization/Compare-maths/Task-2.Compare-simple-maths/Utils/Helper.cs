using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Compare_simple_maths.Utils
{
    public class Helper
    {
        public const int ActionExecutionTimesCount = 100000;

        public static void DisplayExecutionTime(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            action();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
