using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Reflection;

using Company.Client.Contracts;
using Company.Client.Root;
using Company.Repositories;
using Company.Repositories.Contracts;
using Company.Utilities;
using Company.Utilities.Contracts;
using Company.Utilities.DataGenerators;
using Company.Utilities.DataGenerators.Contracts;
using Console.Data;
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

            Bind<DbContext>().To<CompanyEntities>();
            Bind<IClient>().To<ConsoleClient>().InSingletonScope();

            //Bind<INumberGenerator>().To<RandomNumberGenerator>();
            //Bind<IStringGenerator>().To<RandomStringGenerator>();
            //Kernel.Bind<IList<Department>>().ToMethod(x =>
            //{
            //    return new List<Department>();
            //});

            //Bind<IEmployeeGenerator>().To<EmployeeGenerator>();

            //Bind<IProjectGenerator>().To<IProjectGenerator>();
            //Bind<IReportGenerator>().To<IReportGenerator>();
            //Bind<IDepartmentGenerator>().To<IDepartmentGenerator>();
            //Bind<ICompanyContext>().To<ICompanyContext>();
            //Bind<IWorkUnit>().To<EFWorkUnit>();
        }
    }
}