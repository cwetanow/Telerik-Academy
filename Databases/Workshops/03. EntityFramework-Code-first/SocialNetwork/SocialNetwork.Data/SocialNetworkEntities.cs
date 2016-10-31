using System.Data.Entity;
using SocialNetwork.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkEntities : DbContext
    {
        public SocialNetworkEntities()
            : base("SocialNetwork")
        {
        }

        public DbSet<Friendship> Friendships { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
