using System.Data.Entity;

using Dealership.Models;
using Dealership.Repository.Contracts;

namespace Dealership.Repository
{
    public class EFWorkUnit : IWorkUnit
    {
        private readonly DbContext dbContext;

        public EFWorkUnit(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public IRepository<City> CitiesRepository => 
            new EFDealershipRepository<City>(this.dbContext);

        public IRepository<Dealer> DealersRepository => 
            new EFDealershipRepository<Dealer>(this.dbContext);

        public IRepository<Manufacturer> ManufacturersRepository => 
            new EFDealershipRepository<Manufacturer>(this.dbContext);

        public IRepository<Car> CarsRepository =>
            new EFDealershipRepository<Car>(this.dbContext);
    }
}