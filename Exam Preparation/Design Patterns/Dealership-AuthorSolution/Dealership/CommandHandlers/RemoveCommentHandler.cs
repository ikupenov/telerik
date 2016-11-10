using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Models.Contracts;

namespace Dealership.CommandHandlers
{
    public class RemoveCommentHandler : CommandHandler
    {
        private const string CommandName = "RemoveComment";

        private const string NoSuchUser = "There is no user with username {0}!";
        private const string UserNotLogged = "You are not logged! Please login first!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";
        private const string CommentRemovedSuccessfully = "{0} removed comment successfully!";

        private readonly IDataProvider dataProvider;

        public RemoveCommentHandler(IDataProvider dataProvider)
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
            int commentIndex = int.Parse(command.Parameters[1]) - 1;
            string username = command.Parameters[2];

            IUser user = this.dataProvider.RegisteredUsers.ToList()
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, RemovedVehicleDoesNotExist);
            ValidateRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, RemovedCommentDoesNotExist);

            IVehicle vehicle = user.Vehicles[vehicleIndex];
            IComment comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            this.dataProvider.LoggedUser.RemoveComment(comment, vehicle);
            return string.Format(CommentRemovedSuccessfully, this.dataProvider.LoggedUser.Username);
        }
    }
}