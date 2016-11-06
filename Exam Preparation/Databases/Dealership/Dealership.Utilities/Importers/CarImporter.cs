using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using Dealership.Models;
using Dealership.Repository.Contracts;
using Dealership.Utilities.Contracts;
using Dealership.Utilities.JsonModels;
using Newtonsoft.Json;

namespace Dealership.Utilities.Importers
{
    public class CarImporter : IImporter
    {
        private const string DirectoryPath = @"..\..\..\\Data.Json.Files";
        private const string JsonSearchPattern = "data.*.json";

        private readonly IWorkUnit unitOfWork;
        private readonly IRepository<City> citiesRepository;
        private readonly IRepository<Dealer> dealersRepository;
        private readonly IRepository<Manufacturer> manufacturersRepository;
        private readonly IRepository<Car> carsRepository;

        public CarImporter(IWorkUnit unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.citiesRepository = unitOfWork.CitiesRepository;
            this.dealersRepository = unitOfWork.DealersRepository;
            this.manufacturersRepository = unitOfWork.ManufacturersRepository;
            this.carsRepository = unitOfWork.CarsRepository;
        }

        public int Order => 1;

        public void Import()
        {
            string[] jsonFiles = Directory.GetFiles(DirectoryPath, JsonSearchPattern);
            foreach (var file in jsonFiles)
            {
                ImportCars(file);
            }
        }

        private void ImportCars(string file)
        {
            ICollection<Car> carsToImport = new HashSet<Car>();

            string jsonData = File.ReadAllText(file);
            List<CarJson> carsCollection = JsonConvert.DeserializeObject<List<CarJson>>(jsonData);

            foreach (var car in carsCollection)
            {
                var manufacturer = this.manufacturersRepository.Entities
                    .FirstOrDefault(m => m.Name == car.Manufacturer) ??
                new Manufacturer { Name = car.Manufacturer };

                var city = this.citiesRepository.Entities
                    .FirstOrDefault(c => c.Name == car.Dealer.City) ??
                new City { Name = car.Dealer.City };

                var dealer = this.dealersRepository.Entities
                    .FirstOrDefault(d => d.Name == car.Dealer.Name) ??
                new Dealer { Name = car.Dealer.Name, Cities = new Collection<City> { city } };

                var carToImport = new Car
                {
                    Manufacturer = manufacturer,
                    Model = car.Model,
                    Year = car.Year,
                    TransmissionType = car.TransmissionType,
                    Price = car.Price,
                    Dealer = dealer
                };

                this.carsRepository.Add(carToImport);
                this.unitOfWork.Save();
            }
        }
    }
}