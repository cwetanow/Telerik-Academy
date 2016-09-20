using System;
using Task_3.Compare_advanced_maths.Utils;

namespace Task_3.Compare_advanced_maths.Operations
{
    public static class Logarithm
    {
        public static void DisplayAll()
        {
            Console.WriteLine("Time for Loging float:");
            Helper.DisplayExecutionTime(LogFloat);

            Console.WriteLine("Time for Loging double:");
            Helper.DisplayExecutionTime(LogDouble);

            Console.WriteLine("Time for Loging decimal:");
            Helper.DisplayExecutionTime(LogDecimal);
        }

        public static void LogFloat()
        {
            var result = 20000f;
            for (var i = 0f; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = (float)Math.Log((double)result);
            }
        }

        public static void LogDouble()
        {
            var result = 20000.0;
            for (var i = 0.0; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = Math.Log(result);
            }
        }

        public static void LogDecimal()
        {
            var result = 20000m;
            for (var i = 0m; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = (decimal)Math.Log((double)result);
            }
        }
    }
}
