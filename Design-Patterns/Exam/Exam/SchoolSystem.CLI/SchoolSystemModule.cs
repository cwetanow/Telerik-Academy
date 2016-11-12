using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using SchoolSystem.Cli.Interceptors;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Data;
using SchoolSystem.Framework.Services;
using SchoolSystem.Framework.Utils;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string CreateStudentCommandName = "CreateStudent";
        private const string CreateTeacherCommandName = "CreateTeacher";
        private const string RemoveStudentCommandName = "RemoveStudent";
        private const string RemoveTeacherCommandName = "RemoveTeacher";
        private const string StudentListMarksCommandName = "StudentListMarks";
        private const string TeacherAddMarkCommandName = "TeacherAddMark";
        
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<ICommand>()
                .ToMethod(context =>
                {
                    var commandParameterName = (string)context.Parameters.ToList()[0].GetValue(context, context.Request.Target);

                    return context.Kernel.Get<ICommand>(commandParameterName);
                }).When(request => true);

            this.Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommandName);
            this.Bind<ICommand>().To<CreateTeacherCommand>().Named(CreateTeacherCommandName);
            this.Bind<ICommand>().To<RemoveStudentCommand>().Named(RemoveStudentCommandName);
            this.Bind<ICommand>().To<RemoveTeacherCommand>().Named(RemoveTeacherCommandName);
            this.Bind<ICommand>().To<StudentListMarksCommand>().Named(StudentListMarksCommandName);
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().Named(TeacherAddMarkCommandName);

            this.Bind<IWriter>().To<ConsoleWriterProvider>();
            this.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Bind<IParser>().To<CommandParserProvider>();

            this.Bind<Engine>().To<Engine>();

            this.Bind<ICommandFactory>().ToFactory().InSingletonScope();

            this.Bind<IMarkFactory>().ToFactory().InSingletonScope();
            this.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            this.Bind<ITeacherFactory>().ToFactory().InSingletonScope();

            this.Bind(typeof(IRepository<>)).To(typeof(DictionaryRepository<>)).InSingletonScope();

            this.Rebind<ISchoolService>().To<SchoolService>().InSingletonScope();
            this.Rebind<IIdProvider>().To<ThreadIdProvider>().InSingletonScope();

            var configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                this.Rebind<IMarkFactory>().ToFactory().InSingletonScope()
                    .Intercept().With<PerformanceMeasurerInterceptor>();

                this.Rebind<IStudentFactory>().ToFactory().InSingletonScope()
                    .Intercept().With<PerformanceMeasurerInterceptor>();

                this.Rebind<ICommandFactory>().ToFactory().InSingletonScope()
                    .Intercept().With<PerformanceMeasurerInterceptor>();
            }
        }
    }
}