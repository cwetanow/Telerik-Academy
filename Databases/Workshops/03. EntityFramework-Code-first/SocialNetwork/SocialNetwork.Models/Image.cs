using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(2222)]
        public string ImageUrl { get; set; }

        [StringLength(4)]
        public string FileExtension { get; set; }

        public User User { get; set; }
    }
}
