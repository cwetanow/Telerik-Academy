using System.Collections.Generic;

namespace SchoolSystem.Framework.Data
{
    public class DictionaryRepository<T> : IRepository<T>
    {
        public DictionaryRepository()
        {
            this.Entities = new Dictionary<int, T>();
        }

        public IDictionary<int, T> Entities { get; }
    }
}
