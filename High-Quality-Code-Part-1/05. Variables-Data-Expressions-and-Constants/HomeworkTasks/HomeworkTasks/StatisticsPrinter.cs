using System.Linq;

namespace HomeworkTasks
{
    public class StatisticsPrinter
    {
        public void PrintStatistics(double[] arr, int count)
        {
            //Simplified finding min, max and average. Why cycle when there are built in methods 
            var max = arr.Max();
            this.PrintMax(max);

            var min = arr.Min();
            this.PrintMin(min);

            var average = arr.Average();
            this.PrintAvg(average);
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
