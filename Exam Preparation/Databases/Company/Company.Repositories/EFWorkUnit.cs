using System.Data.Entity;
using Company.Repositories.Contracts;

namespace Company.Repositories
{
    public class EFWorkUnit : IWorkUnit
    {
        private readonly DbContext dbContext;

        public EFWorkUnit(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}