using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirst.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string StudentNumber { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
