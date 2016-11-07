using System.Data.Entity;

using ToyStore.Repository.Contracts;

namespace ToyStore.Repository
{
    public class EFWorkUnit : IWorkUnit
    {
        private readonly DbContext dbContext;

        public EFWorkUnit(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save() => this.dbContext.SaveChanges();

        public void Dispose()
        {
        }
    }
}