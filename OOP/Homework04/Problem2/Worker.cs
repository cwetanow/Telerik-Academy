using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Worker : Human
    {
        private int weekSalary;

        private int workHoursPerDay;

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set {
                if (value>24)
                {
                    throw new ArgumentException("Impossibru");
                }
                if (value<0)
                {
                    throw new ArgumentException("Get a job");
                }
                
                this.workHoursPerDay = value; }
        }
        
        public int WeekSalary
        {
            get { return this.weekSalary; }
            set {
                if (value<0)
                {
                    throw new ArgumentException("Get a new job man!");
                }
                this.weekSalary = value; }
        }
        
        
        public Worker(string first, string last, int weeksal, int workhours) : base(first, last)
        {
            this.WeekSalary = weeksal;
            this.WorkHoursPerDay = workhours;
        }
        public int MoneyPerHour() {
            return (this.WeekSalary / 7) / this.WorkHoursPerDay;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} Salary: {2} per h",this.FirstName,this.LastName,this.MoneyPerHour());
        }
    }
}
