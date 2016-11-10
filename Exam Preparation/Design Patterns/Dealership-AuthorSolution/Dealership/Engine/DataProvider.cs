using System.Collections.Generic;

using Dealership.Models.Contracts;

namespace Dealership.Engine
{
    public class DataProvider : IDataProvider
    {
        private IUser loggedUser;

        public DataProvider()
        {
            this.RegisteredUsers = new HashSet<IUser>();
        }

        public IUser LoggedUser
        {
            get
            {
                return this.loggedUser;
            }

            set
            {
                this.loggedUser = value;
            }
        }

        public ICollection<IUser> RegisteredUsers { get; private set; }

        public void WipeData()
        {
            this.LoggedUser = null;
            this.RegisteredUsers = new HashSet<IUser>();
        }
    }
}