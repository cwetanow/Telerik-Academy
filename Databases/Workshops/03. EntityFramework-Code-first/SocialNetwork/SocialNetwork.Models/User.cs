using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class User
    {
        public User()
        {
            this.Images = new HashSet<Image>();
            this.Messages = new HashSet<Message>();
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 4)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Firstname { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Lastname { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
