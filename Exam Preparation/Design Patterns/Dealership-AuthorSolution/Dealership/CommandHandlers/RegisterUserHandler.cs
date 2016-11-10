using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.Common.Enums;
using Dealership.Common.Utilities;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Models.Contracts;

namespace Dealership.CommandHandlers
{
    public class RegisterUserHandler : CommandHandler
    {
        private const string CommandName = "RegisterUser";

        private const string UserLoggedIn = "User {0} is logged in! Please log out first!";
        private const string UserRegisterеd = "User {0} registered successfully!";
        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";

        private readonly IDataProvider dataProvider;
        private readonly IDealershipFactory dealershipFactory;

        public RegisterUserHandler(IDataProvider dataProvider, IDealershipFactory dealershipFactory)
        {
            this.dataProvider = dataProvider;
            this.dealershipFactory = dealershipFactory;
        }

        protected override bool CanHandle(ICommand command) =>
            command.Name.ToLower() == CommandName.ToLower() ? true : false;

        protected override string Handle(ICommand command)
        {
            if (this.dataProvider.LoggedUser != null)
            {
                return string.Format(UserLoggedIn, this.dataProvider.LoggedUser.Username);
            }

            string username = command.Parameters[0];
            string firstName = command.Parameters[1];
            string lastName = command.Parameters[2];
            string password = command.Parameters[3];

            Role role = command.Parameters.Count > 4
                ? command.Parameters[4].ParseToEnum<Role>()
                : Role.Normal;

            bool doesExist = this.dataProvider
                .RegisteredUsers.Any(u => u.Username.ToLower() == username.ToLower());

            if (doesExist)
            {
                return string.Format(UserAlreadyExist, username);
            }
            else
            {
                IUser user = this.dealershipFactory.CreateUser(
                    username,
                    firstName,
                    lastName,
                    password,
                    role);

                this.dataProvider.RegisteredUsers.Add(user);
                this.dataProvider.LoggedUser = user;

                return string.Format(UserRegisterеd, user.Username);
            }
        }
    }
}