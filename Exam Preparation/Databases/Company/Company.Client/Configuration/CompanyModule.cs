using System.Data.Entity;
using System.IO;
using System.Reflection;

using Company.Data;
using Company.Client.Contracts;
using Company.Client.Root;

using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Company.Client.Configuration
{
    public class CompanyModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .SelectAllClasses()
                    .BindDefaultInterfaces();
            });

            Bind<DbContext>().To<CompanyEntities>().InSingletonScope();
            Bind<IClient>().To<ConsoleClient>().InSingletonScope();
        }
    }
}