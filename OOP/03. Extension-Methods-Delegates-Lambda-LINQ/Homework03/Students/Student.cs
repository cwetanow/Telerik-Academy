using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03.Students
{
    class Student
    {
        private string firstName;
        private string lastName;
        private string fn;
        private int age;
        private string tel;
        private string email;
        private List<double> marks;
        private Group group;
        public Student(string first, string last, string number, string tel, string mail, List<double> marks, Group group, int age)
        {
            this.FirstName = first;
            this.LastName = last;
            this.FN = number;
            this.Tel = tel;
            this.Email = mail;
            this.Marks = marks;
            this.Group = group;
            this.Age = age;
        }
        public List<double> Marks
        {
            get
            { return this.marks; }
            set
            {
                foreach (var item in value)
                {
                    if (item < 2 || item > 6)
                    {
                        throw new ArgumentException("Invalid grade");
                    }

                }
                this.marks = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid age");
                }
                this.age = value;
            }
        }
        public string FirstName
        {
            get
            { return this.firstName; }
            set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            { return this.lastName; }
            set
            {
                this.lastName = value;
            }
        }
        public string FN
        {
            get
            { return this.fn; }
            set
            {
                this.fn = value;
            }
        }
        public string Tel
        {
            get
            { return this.tel; }
            set
            {
                this.tel = value;
            }
        }
        public string Email
        {
            get
            { return this.email; }
            set
            {
                this.email = value;
            }
        }


        public Group Group
        {
            get { return this.group; }
            set { this.group = value; }
        }

       
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.FirstName, this.LastName, this.Age);
        }

    }
}
