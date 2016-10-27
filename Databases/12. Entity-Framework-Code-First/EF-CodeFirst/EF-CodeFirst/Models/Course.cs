using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirst.Models
{
    public class Course
    {
        public Course()
        {
            this.Materials = new HashSet<Material>();
            this.Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
