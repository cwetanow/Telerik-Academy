using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirst.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public Course Course { get; set; }
    }
}
