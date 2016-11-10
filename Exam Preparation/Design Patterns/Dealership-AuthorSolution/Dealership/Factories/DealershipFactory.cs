using Dealership.Models;
using Dealership.Common.Enums;
using Dealership.Engine;
using Dealership.Models.Contracts;

namespace Dealership.Factories
{
    public class DealershipFactory : IDealershipFactory
    {
        public IVehicle CreateCar(string make, string model, decimal price, int seats)
        {
            return new Car(make, model, price, seats);
        }

        public IVehicle CreateMotorcycle(string make, string model, decimal price, string category)
        {
            return new Motorcycle(make, model, price, category);
        }

        public IVehicle CreateTruck(string make, string model, decimal price, int weightCapacity)
        {
            return new Truck(make, model, price, weightCapacity);
        }

        public IUser CreateUser(string username, string firstName, string lastName, string password, Role role)
        {
            return new User(username, firstName, lastName, password, role);
        }

        public IComment CreateComment(string content)
        {
            return new Comment(content);
        }

        public ICommand CreateCommand(string command)
        {
            return new Command(command);
        }
    }
}
