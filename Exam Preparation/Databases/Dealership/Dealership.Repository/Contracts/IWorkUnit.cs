using Dealership.Models;

namespace Dealership.Repository.Contracts
{
    public interface IWorkUnit
    {
        void Save();

        IRepository<City> CitiesRepository { get; }

        IRepository<Dealer> DealersRepository { get; }

        IRepository<Manufacturer> ManufacturersRepository { get; }

        IRepository<Car> CarsRepository { get; }
    }
}