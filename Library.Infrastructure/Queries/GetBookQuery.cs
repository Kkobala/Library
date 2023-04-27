using Library.Domain.Db.Entities;
using MediatR;

namespace Library.Infrastructure.Queries
{
    public class GetBookQuery : IRequest<List<BookEntity>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
