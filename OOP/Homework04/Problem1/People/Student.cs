using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.People
{
    public class Student : Person
    {
        private int classNumber;

        public int ClassNumber  
        {
            get { return classNumber; }
            set { classNumber = value; }
        }
        
        public Student(string name, int classNumber) : base(name)
        {
            this.ClassNumber = classNumber;
        }
    }
}
