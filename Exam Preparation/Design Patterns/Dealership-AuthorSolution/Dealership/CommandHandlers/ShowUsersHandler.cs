using System.Linq;
using System.Text;

using Dealership.CommandHandlers.Base;
using Dealership.Common.Enums;
using Dealership.Engine;
using Dealership.Models.Contracts;

namespace Dealership.CommandHandlers
{
    public class ShowUsersHandler : CommandHandler
    {
        private const string CommandName = "ShowUsers";

        private const string YouAreNotAnAdmin = "You are not an admin!";
        private const string UserNotLogged = "You are not logged! Please login first!";

        private const string Header = "--USERS--";

        private readonly IDataProvider dataProvider;

        public ShowUsersHandler(IDataProvider dataProvider)
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

            if (this.dataProvider.LoggedUser.Role != Role.Admin)
            {
                return YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine(Header);

            var users = this.dataProvider.RegisteredUsers.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                IUser user = users[i];
                builder.AppendLine($"{i}. {user.ToString()}");
            }

            return builder.ToString().Trim();
        }
    }
}