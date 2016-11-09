using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SuperheroesUniverse.Data.Repositories
{
    public class EfRepository<T> : IRepository<T>
       where T : class
    {
        public EfRepository(SuperheroeEntities dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Context cannot be null");
            }

            this.DbContext = dbContext;
            this.DbSet = this.DbContext.Set<T>();
        }
        protected SuperheroeEntities DbContext { get; set; }

        protected IDbSet<T> DbSet { get; set; }


        public IEnumerable<T> Entities => this.DbSet.ToList();

        public void Add(T entity)
        {
            var entry = this.DbContext.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.DbContext.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.DbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
