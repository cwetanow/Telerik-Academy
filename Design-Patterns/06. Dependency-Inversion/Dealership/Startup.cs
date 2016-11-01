using Dealership.Engine;
using System;
using System.IO;
using System.Reflection;
using Dealership.Core;
using Ninject;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
