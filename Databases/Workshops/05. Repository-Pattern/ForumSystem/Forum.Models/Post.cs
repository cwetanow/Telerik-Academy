using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class Post
    {
        private ICollection<Tag> tags;
        private ICollection<Comment> comments;

        public Post()
        {
            this.CreatedOn = DateTime.Now;

            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int PostId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public PostType Type { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
