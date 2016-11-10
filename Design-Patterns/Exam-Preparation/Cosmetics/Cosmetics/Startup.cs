using System.Reflection;
using Cosmetics.Contracts;
using Ninject;

namespace Cosmetics
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
