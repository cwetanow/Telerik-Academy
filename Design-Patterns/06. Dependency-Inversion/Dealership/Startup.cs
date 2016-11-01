using Dealership.Engine;
using System.Reflection;
using Ninject;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Get<IEngine>().Start();
        }
    }
}
