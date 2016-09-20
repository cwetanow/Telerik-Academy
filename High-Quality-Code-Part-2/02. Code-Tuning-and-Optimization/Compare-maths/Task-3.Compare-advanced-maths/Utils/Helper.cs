using System;
using System.Diagnostics;

namespace Task_3.Compare_advanced_maths.Utils
{
    public class Helper
    {
        public const int ActionExecutionTimesCount = 10000;

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
