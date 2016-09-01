using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTasks
{
    public class StatisticsPrinter
    {
        public void PrintStatistics(double[] arr, int count)
        {
            //Simplified finding min, max and average. Why cycle when there are built in methods 
            var max = arr.Max();
            PrintMax(max);

            var min = arr.Min();
            PrintMin(min);

            var average = arr.Average();
            PrintAvg(average);
        }

        private void PrintMax(double max)
        {

        }

        private void PrintAvg(double d)
        {

        }

        private void PrintMin(double max)
        {

        }
    }
}
