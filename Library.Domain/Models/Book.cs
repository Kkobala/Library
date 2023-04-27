using Library.Domain.Db.Entities;

namespace Library.App.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorEntity Author { get; set; }
    }
}
