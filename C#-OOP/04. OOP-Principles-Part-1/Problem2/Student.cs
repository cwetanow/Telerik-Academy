using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Student : Human
    {
        private int grade;

        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }
        public Student(string first, string last, int grade) : base(first, last)
        {
            this.Grade = grade;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} Grade: {2}", this.FirstName, this.LastName, this.Grade);
        }

    }
}
