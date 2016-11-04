using System;

namespace Forum.Data
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ForumEntities dbContext;

        public EfUnitOfWork(ForumEntities context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context cannot be null");
            }

            this.dbContext = context;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
