using System.Data.Entity;

using Bookstore.Data;
using Bookstore.Data.Migrations;

namespace Bookstore.Client
{
    internal class StartUp
    {
        private const string ComplexBooksXmlPath = @"..\..\..\Other\complex-books.xml";

        private static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreEntities, Configuration>());

            var dbContext = new BookstoreEntities();
            dbContext.Database.Initialize(true);

            var xmlImporter = new XmlImporter(dbContext);
            xmlImporter.Import(ComplexBooksXmlPath);
        }
    }
}
