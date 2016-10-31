using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Post
    {
        public Post()
        {
            this.TaggedUsers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(10)]
        [Required]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual ICollection<User> TaggedUsers { get; set; }
    }
}
