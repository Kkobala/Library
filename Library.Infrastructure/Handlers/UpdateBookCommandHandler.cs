using Library.Domain.Db;
using Library.Infrastructure.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public UpdateBookCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Title == request.Title);

            if (book == null)
            {
                throw new ArgumentException("Book not found");
            }

            book.Description = request.Description;

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
