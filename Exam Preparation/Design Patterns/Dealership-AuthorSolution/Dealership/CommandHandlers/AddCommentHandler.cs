using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Models.Contracts;

namespace Dealership.CommandHandlers
{
    public class AddCommentHandler : CommandHandler
    {
        private const string CommandName = "AddComment";

        private const string UserNotLogged = "You are not logged! Please login first!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string CommentAddedSuccessfully = "{0} added comment successfully!";

        private readonly IDataProvider dataProvider;
        private readonly IDealershipFactory dealershipFactory;

        public AddCommentHandler(IDataProvider dataProvider, IDealershipFactory dealershipFactory)
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

            string content = command.Parameters[0];
            string author = command.Parameters[1];
            int vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            IComment comment = this.dealershipFactory.CreateComment(content);
            comment.Author = this.dataProvider.LoggedUser.Username;

            IUser user = this.dataProvider.RegisteredUsers.ToList()
                .FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(NoSuchUser, author);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, VehicleDoesNotExist);

            IVehicle vehicle = user.Vehicles[vehicleIndex];
            this.dataProvider.LoggedUser.AddComment(comment, vehicle);

            return string.Format(CommentAddedSuccessfully, this.dataProvider.LoggedUser.Username);
        }
    }
}