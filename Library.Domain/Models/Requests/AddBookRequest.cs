using Library.Domain.Db.Entities;

namespace Library.App.Models.Requests
{
    public class AddBookRequest
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
