using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Models.Contracts;

namespace Dealership.CommandHandlers
{
    public class RemoveVehicleHandler : CommandHandler
    {
        private const string CommandName = "RemoveVehicle";

        private const string UserNotLogged = "You are not logged! Please login first!";
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";

        private readonly IDataProvider dataProvider;

        public RemoveVehicleHandler(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        protected override bool CanHandle(ICommand command) =>
            command.Name.ToLower() == CommandName.ToLower() ? true : false;

        protected override string Handle(ICommand command)
        {
            if (this.dataProvider.LoggedUser == null)
            {
                return UserNotLogged;
            }

            int vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            ValidateRange(vehicleIndex, 0, this.dataProvider.LoggedUser.Vehicles.Count, RemovedVehicleDoesNotExist);

            IVehicle vehicle = this.dataProvider.LoggedUser.Vehicles[vehicleIndex];
            this.dataProvider.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(VehicleRemovedSuccessfully, this.dataProvider.LoggedUser.Username);
        }
    }
}