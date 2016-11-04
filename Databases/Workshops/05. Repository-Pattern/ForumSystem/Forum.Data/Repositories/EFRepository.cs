using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Forum.Data.Repositories
{
    public class EfRepository<T> : IRepository<T>
        where T : class
    {
        public EfRepository(ForumEntities dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Context cannot be null");
            }

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
            return this.DbSet
                .Where(filterExpression);
        }

        public IEnumerable<T> GetAll<T1>(System.Linq.Expressions.Expression<Func<T, bool>> filterExpression, System.Linq.Expressions.Expression<Func<T, T1>> sortExpression)
        {
            return this.DbSet
                .Where(filterExpression)
                .OrderBy(sortExpression);
        }

        public IEnumerable<T2> GetAll<T1, T2>(System.Linq.Expressions.Expression<Func<T, bool>> filterExpression, System.Linq.Expressions.Expression<Func<T, T1>> sortExpression, System.Linq.Expressions.Expression<Func<T, T2>> selectExpression)
        {
            return this.DbSet
                .Where(filterExpression)
                .OrderBy(sortExpression)
                .Select(selectExpression);
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
