using System.Data.Entity;

using Dealership.Data;
using Dealership.Data.Migrations;

namespace Dealership.Application
{
    internal class StartUp
    {
        private static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DealershipContext, Configuration>());

            DealershipContext context = new DealershipContext();
            context.Database.Initialize(true);
        }
    }
}