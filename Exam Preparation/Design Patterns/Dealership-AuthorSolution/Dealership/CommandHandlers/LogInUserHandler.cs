using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Models.Contracts;

namespace Dealership.CommandHandlers
{
    public class LogInUserHandler : CommandHandler
    {
        private const string CommandName = "Login";

        private const string UserLoggedIn = "User {0} successfully logged in!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";
        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";

        private readonly IDataProvider dataProvider;

        public LogInUserHandler(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        protected override bool CanHandle(ICommand command) =>
            command.Name.ToLower() == CommandName.ToLower() ? true : false;

        protected override string Handle(ICommand command)
        {
            string username = command.Parameters[0];
            string password = command.Parameters[1];

            IUser user = this.dataProvider.RegisteredUsers
                .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user != null && user.Password == password)
            {
                this.dataProvider.LoggedUser = user;
                return string.Format(UserLoggedIn, username);
            }

            return WrongUsernameOrPassword;
        }
    }
}