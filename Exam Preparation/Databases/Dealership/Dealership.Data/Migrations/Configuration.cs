using System.Data.Entity.Migrations;

namespace Dealership.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DealershipContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DealershipContext context)
        {
        }
    }
}