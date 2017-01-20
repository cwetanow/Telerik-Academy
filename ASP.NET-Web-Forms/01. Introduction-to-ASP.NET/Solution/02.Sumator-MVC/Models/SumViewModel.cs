namespace _02.Sumator_MVC.Models
{
    public class SumViewModel
    {
        public SumViewModel()
        {
            this.FirstNumber = 0;
            this.SecondNumber = 0;
            this.Sum = 0;
        }

        public double? FirstNumber { get; set; }

        public double? SecondNumber { get; set; }

        public double? Sum { get; set; }
    }
}