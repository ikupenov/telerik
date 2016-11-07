using System;

namespace Bookstore.Models
{
    public class Review
    {
        public int Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}