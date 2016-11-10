using System.Collections.Generic;

using Dealership.Models.Contracts;

namespace Dealership.Engine
{
    public interface IDataProvider
    {
        IUser LoggedUser { get; set; }

        ICollection<IUser> RegisteredUsers { get; }

        void WipeData();
    }
}