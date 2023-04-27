using Library.Domain.Db.Entities;
using Library.Domain.Db;
using Library.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Handlers
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, List<BookEntity>>
    {
        private readonly AppDbContext _dbContext;

        public GetBookQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookEntity>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.PageIndex - 1) * request.PageSize;
            var books = await _dbContext.Books
                .OrderBy(b => b.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return books;
        }
    }
}
