using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Forum.Data.Repositories
{
    public class EfRepository<T> : IRepository<T>
        where T : class
    {
        public EfRepository(ForumEntities dbContext)
        {
            this.dbContext = dbContext;
            this.DbSet = this.dbContext.Set<T>();
        }
        protected ForumEntities dbContext { get; set; }

        protected IDbSet<T> DbSet { get; set; }


        public IEnumerable<T> Entities
        {
            get { return this.DbSet; }
        }

        public void Add(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T1>(System.Linq.Expressions.Expression<Func<T, bool>> filterExpression, System.Linq.Expressions.Expression<Func<T, T1>> sortExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T2> GetAll<T1, T2>(System.Linq.Expressions.Expression<Func<T, bool>> filterExpression, System.Linq.Expressions.Expression<Func<T, T1>> sortExpression, System.Linq.Expressions.Expression<Func<T, T2>> selectExpression)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
