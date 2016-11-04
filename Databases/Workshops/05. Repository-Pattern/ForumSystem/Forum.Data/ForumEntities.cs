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

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
