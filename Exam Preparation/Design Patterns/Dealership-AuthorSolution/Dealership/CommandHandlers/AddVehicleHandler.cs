using Dealership.CommandHandlers.Base;
using Dealership.Common.Enums;
using Dealership.Common.Utilities;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Models.Contracts;

namespace Dealership.CommandHandlers
{
    public class AddVehicleHandler : CommandHandler
    {
        private const string CommandName = "AddVehicle";

        private const string UserNotLogged = "You are not logged! Please login first!";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        private readonly IDataProvider dataProvider;
        private readonly IDealershipFactory dealershipFactory;

        public AddVehicleHandler(IDataProvider dataProvider, IDealershipFactory dealershipFactory)
        {
            this.dataProvider = dataProvider;
            this.dealershipFactory = dealershipFactory;
        }

        protected override bool CanHandle(ICommand command) =>
            command.Name.ToLower() == CommandName.ToLower() ? true : false;

        protected override string Handle(ICommand command)
        {
            if (this.dataProvider.LoggedUser == null)
            {
                return UserNotLogged;
            }

            var type = command.Parameters[0].ParseToEnum<VehicleType>();
            string make = command.Parameters[1];
            string model = command.Parameters[2];
            decimal price = decimal.Parse(command.Parameters[3]);
            string additionalParam = command.Parameters[4];

            IVehicle vehicle = null;

            switch (type)
            {
                case VehicleType.Car:
                    vehicle = this.dealershipFactory.CreateCar(make, model, price, int.Parse(additionalParam));
                    break;
                case VehicleType.Motorcycle:
                    vehicle = this.dealershipFactory.CreateMotorcycle(make, model, price, additionalParam);
                    break;
                case VehicleType.Truck:
                    vehicle = this.dealershipFactory.CreateTruck(make, model, price, int.Parse(additionalParam));
                    break;
            }

            this.dataProvider.LoggedUser.AddVehicle(vehicle);
            return string.Format(VehicleAddedSuccessfully, this.dataProvider.LoggedUser.Username);
        }
    }
}