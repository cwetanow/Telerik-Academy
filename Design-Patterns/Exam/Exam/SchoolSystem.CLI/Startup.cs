using System.Reflection;
using Ninject;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var engine = kernel.Get<Engine>();
            engine.Start();
        }
    }
}