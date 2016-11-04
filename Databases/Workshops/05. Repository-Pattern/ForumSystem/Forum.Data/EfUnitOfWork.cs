using System;

namespace Forum.Data
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ForumEntities dbContext;

        public EfUnitOfWork(ForumEntities context)
        {
            this.dbContext = context;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
