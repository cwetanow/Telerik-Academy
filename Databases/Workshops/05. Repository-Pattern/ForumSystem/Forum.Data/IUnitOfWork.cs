using System;

namespace Forum.Data
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
