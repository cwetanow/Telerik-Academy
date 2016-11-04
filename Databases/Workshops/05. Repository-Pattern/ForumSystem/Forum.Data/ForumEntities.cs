using System.Data.Entity;
using Forum.Models;

namespace Forum.Data
{
    public class ForumEntities : DbContext
    {
        public ForumEntities()
            : base("ForumDb")
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
