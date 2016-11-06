using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Dealership.Models;

namespace Dealership.Data
{
    public class DealershipContext : DbContext
    {
        public DealershipContext()
            : base("Dealership")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Dealer> Dealers { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}