using System.IO;
using System.Linq;
using System.Xml.Serialization;

using Bookstore.Client.XmlModels;
using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Client
{
    public class XmlImporter
    {
        private readonly BookstoreEntities dbContext;

        public XmlImporter(BookstoreEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Import(string url)
        {
            using (var reader = new StreamReader(url))
            {
                var serializer = new XmlSerializer(typeof(CatalogXmlRoot));
                var catalog = (CatalogXmlRoot)serializer.Deserialize(reader);

                foreach (var book in catalog.Books)
                {
                    var bookToImport = new Book
                    {
                        Title = book.Title,
                        Isbn = book.Isbn,
                        Authors = book.Author.Select(a =>
                        {
                            return this.dbContext.Authors.FirstOrDefault(a1 => a1.Name == a.Name) ??
                                   new Author { Name = a.Name };
                        }).ToList(),
                        Price = book.Price,
                        Website = book.Website,
                        Reviews = book.Reviews.Select(r =>
                        {
                            return new Review
                            {
                                Author = r.Author == null ? null :
                                    this.dbContext.Authors.FirstOrDefault(a => a.Name == r.Author) ??
                                         new Author { Name = r.Author },
                                DateOfCreation = r.PostDate
                            };
                        }).ToList()
                    };

                    this.dbContext.Books.Add(bookToImport);
                    this.dbContext.SaveChanges();
                }
            }
        }
    }
}