using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SuperheroesUniverse.Data.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(object id);

        IEnumerable<T> Entities { get; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
