using Library.Domain.Db;
using Library.Infrastructure.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Handlers
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public RemoveBookCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       public async Task<Unit> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Title == request.Title);

            if (book == null)
            {
                throw new ArgumentException("Book not found");
            }

            _dbContext.Books.Remove(book);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
