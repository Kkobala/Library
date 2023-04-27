using Library.Domain.Db.Entities;
using MediatR;

namespace Library.Infrastructure.Queries
{
    public class GetBooksByAuthorQuery : IRequest<List<BookEntity>>
    {
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public GetBooksByAuthorQuery(string authorName, string authorLastName)
        {
            AuthorName = authorName;
            AuthorLastName = authorLastName;
        }
    }
}
