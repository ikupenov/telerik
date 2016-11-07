using System.Data.Entity;

using Bookstore.Models;

namespace Bookstore.Data
{
    public class BookstoreEntities : DbContext
    {
        public BookstoreEntities()
            : base("Bookstore")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}