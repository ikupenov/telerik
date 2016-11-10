using Dealership.CommandHandlers.Base;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class LogOutUserHandler : CommandHandler
    {
        private const string CommandName = "Logout";

        private const string UserAlreadyLoggedIn = "There is a logged in user already.";
        private const string UserLoggedOut = "You logged out!";

        private readonly IDataProvider dataProvider;

        public LogOutUserHandler(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        protected override bool CanHandle(ICommand command) =>
            command.Name.ToLower() == CommandName.ToLower() ? true : false;

        protected override string Handle(ICommand command)
        {
            bool isLoggedIn = this.dataProvider.LoggedUser != null;
            if (!isLoggedIn)
            {
                return UserAlreadyLoggedIn;
            }
            else
            {
                this.dataProvider.LoggedUser = null;
                return UserLoggedOut;
            }
        }
    }
}