using System.Data.Entity;

using Company.Client.Configuration;
using Company.Client.Contracts;

using Ninject;

namespace Company.Client
{
    internal class StartUp
    {
        private static void Main()
        {
            IKernel kernel = new StandardKernel(new CompanyModule());

            DbContext dbContext = kernel.Get<DbContext>();
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;

            IClient client = kernel.Get<IClient>();
            client.Start();
        }
    }
}