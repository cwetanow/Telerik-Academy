using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace School
{
    public class Course
    {
        private IList<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public void StudentJoins(Student student)
        {
            if (this.students.Count == 30)
            {
                throw new ArgumentException("Students cannot be more than 30");
            }
            this.students.Add(student);
        }

        public bool StudentLeaves(Student student)
        {
            if (this.students.Count == 0)
            {
                throw new ArgumentException("No students");
            }
            return this.students.Remove(student);
        }

        public int Count { get { return this.students.Count; } }
    }
}
