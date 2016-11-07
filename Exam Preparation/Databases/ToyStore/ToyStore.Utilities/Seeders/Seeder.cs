using System;
using System.Data.Entity;
using System.Linq;

using ToyStore.Data;
using ToyStore.Repository;
using ToyStore.Repository.Contracts;
using ToyStore.Utilities.Generators;

namespace ToyStore.Utilities.Seeders
{
    public abstract class Seeder
    {
        private static DbContext dbContext;

        static Seeder()
        {
            dbContext = new ToyStoreEntities();

            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        protected abstract int Order { get; }

        protected Func<IWorkUnit> UnitOfWork => () => new EFWorkUnit(dbContext);

        protected IRepository<Manufacturer> ManufacturersRepository =>
            new EFRepository<Manufacturer>(dbContext);

        protected IRepository<AgeRanx> AgeRangesRepository =>
            new EFRepository<AgeRanx>(dbContext);

        protected IRepository<Category> CategoriesRepository =>
            new EFRepository<Category>(dbContext);

        protected IRepository<Toy> ToysRepository => new EFRepository<Toy>(dbContext);

        protected NumberGenerator NumberGenerator => new NumberGenerator();

        protected StringGenerator StringGenerator =>
            new StringGenerator(this.NumberGenerator);

        public static void Seed()
        {
            AppDomain.CurrentDomain.GetAssemblies()
                 .SelectMany(a => a.DefinedTypes)
                 .Where(t => t.IsSubclassOf(typeof(Seeder)) &&
                             !t.IsAbstract &&
                             !t.IsInterface)
                 .Select(t => (Seeder)Activator.CreateInstance(t))
                 .OrderBy(i => i.Order)
                 .ToList()
                 .ForEach(i => i.SeedDatabase());
        }

        public abstract void SeedDatabase();
    }
}