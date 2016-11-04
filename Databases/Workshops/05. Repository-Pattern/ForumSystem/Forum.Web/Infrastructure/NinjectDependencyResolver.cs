using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Data;
using Forum.Data.Repositories;
using Ninject;

namespace Forum.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;

            this.AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this.kernel.Bind<IUnitOfWork>().To<EfUnitOfWork>();
            this.kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            this.kernel.Bind<DbContext>().To<ForumEntities>();
        }
    }
}