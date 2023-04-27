using Library.Domain.Db.Entities;

namespace Library.Domain.Models.Requests
{
    public class GetBookByAuthorRequest
    {
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
