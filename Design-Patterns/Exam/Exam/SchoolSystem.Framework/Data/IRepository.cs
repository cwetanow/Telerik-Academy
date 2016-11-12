using System.Collections.Generic;

namespace SchoolSystem.Framework.Data
{
    public interface IRepository<T>
    {
        IDictionary<int, T> Entities { get; }
    }
}
