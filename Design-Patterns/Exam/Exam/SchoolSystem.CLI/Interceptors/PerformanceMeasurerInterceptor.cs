using System.Diagnostics;
using Ninject.Extensions.Interception;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Cli.Interceptors
{
    public class PerformanceMeasurerInterceptor : IInterceptor
    {
        private const string CallingMethod = "Calling method {0} of type {1}...";
        private const string TotalTime = "Total execution time for method {0} of type {1} is {2} milliseconds.";

        private readonly IWriter writer;

        public PerformanceMeasurerInterceptor(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            this.writer.WriteLine(string.Format(CallingMethod,
                invocation.Request.Method.Name,
                invocation.Request.Method.DeclaringType.Name));

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            invocation.Proceed();

            this.writer.WriteLine(string.Format(TotalTime,
                invocation.Request.Method.Name,
                invocation.Request.Method.DeclaringType.Name,
                stopwatch.ElapsedMilliseconds));
        }
    }
}
