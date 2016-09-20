using System;
using Task_3.Compare_advanced_maths.Utils;

namespace Task_3.Compare_advanced_maths.Operations
{
    public static class Sinus
    {
        public static void DisplayAll()
        {
            Console.WriteLine("Time for Sining float:");
            Helper.DisplayExecutionTime(SinFloat);

            Console.WriteLine("Time for Sining double:");
            Helper.DisplayExecutionTime(SinDouble);

            Console.WriteLine("Time for Sining decimal:");
            Helper.DisplayExecutionTime(SinDecimal);
        }

        public static void SinFloat()
        {
            var result = 20000f;
            for (var i = 0f; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = (float)Math.Sin((double)result);
            }
        }

        public static void SinDouble()
        {
            var result = 20000.0;
            for (var i = 0.0; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = Math.Sin(result);
            }
        }

        public static void SinDecimal()
        {
            var result = 20000m;
            for (var i = 0m; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = (decimal)Math.Sin((double)result);
            }
        }
    }
}
