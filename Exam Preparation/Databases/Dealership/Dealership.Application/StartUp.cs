using System.Data.Entity;

using Dealership.Data;
using Dealership.Data.Migrations;
using Dealership.Repository;
using Dealership.Utilities.Importers;

namespace Dealership.Application
{
    internal class StartUp
    {
        private static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DealershipContext, Configuration>());

            DealershipContext context = new DealershipContext();
            context.Database.Initialize(true);

            var unitOfWork = new EFWorkUnit(context);
            var carImporter = new CarImporter(unitOfWork);
            carImporter.Import();
        }
    }
}