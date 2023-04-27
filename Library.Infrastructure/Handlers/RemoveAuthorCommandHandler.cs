using Library.Domain.Db;
using Library.Infrastructure.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Handlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public RemoveAuthorCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Name == request.Name && a.LastName == request.LastName);

            if (author == null)
            {
                throw new ArgumentException("Author not found");
            }

            _dbContext.Authors.Remove(author);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
