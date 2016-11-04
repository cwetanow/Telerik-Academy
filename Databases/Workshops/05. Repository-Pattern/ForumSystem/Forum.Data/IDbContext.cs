using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Forum.Models;

namespace Forum.Data
{
    public interface IDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
