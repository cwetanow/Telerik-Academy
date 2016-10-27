using System.Data.Entity;
using EF_CodeFirst.Models;

namespace EF_CodeFirst.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("SchoolSystem")
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}
