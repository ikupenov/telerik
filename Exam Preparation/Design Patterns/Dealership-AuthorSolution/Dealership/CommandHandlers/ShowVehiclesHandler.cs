using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Models.Contracts;

namespace Dealership.CommandHandlers
{
    public class ShowVehiclesHandler : CommandHandler
    {
        private const string CommandName = "ShowVehicles";
        private const string NoSuchUser = "There is no user with username {0}!";

        private readonly IDataProvider dataProvider;

        public ShowVehiclesHandler(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        protected override bool CanHandle(ICommand command) =>
            command.Name.ToLower() == CommandName.ToLower() ? true : false;

        protected override string Handle(ICommand command)
        {
            string username = command.Parameters[0];

            IUser user = this.dataProvider.RegisteredUsers.ToList()
                .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}