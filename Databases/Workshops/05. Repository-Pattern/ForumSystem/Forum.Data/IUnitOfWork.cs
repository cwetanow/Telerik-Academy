using System;

namespace Forum.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
