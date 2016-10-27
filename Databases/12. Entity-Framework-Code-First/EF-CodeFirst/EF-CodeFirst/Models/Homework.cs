using System;
using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirst.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Datesent { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}
