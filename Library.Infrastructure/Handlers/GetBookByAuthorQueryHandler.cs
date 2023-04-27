using Library.Domain.Db;
using Library.Domain.Db.Entities;
using Library.Infrastructure.Queries;
using Library.Infrastructure.Repositories.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Handlers
{
    public class GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, List<BookEntity>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IBookQueryRepository _bookQueryRepository;

        public GetBooksByAuthorQueryHandler(AppDbContext dbContext,
            IBookQueryRepository bookQueryRepository)
        {
            _dbContext = dbContext;
            _bookQueryRepository = bookQueryRepository;
        }

        public async Task<List<BookEntity>> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
        {
            var books = await _dbContext.Books
                .Include(b => b.Author)
                .Where(b => b.Author.Name == request.AuthorName && b.Author.LastName == request.AuthorLastName)
                .OrderBy(b => b.Title)
                .Skip(request.PageIndex * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return books;
        }
    }
}
