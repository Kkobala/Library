using Library.Domain.Db.Entities;
using Library.Domain.Db;
using Library.Infrastructure.Command;
using MediatR;

namespace Library.Infrastructure.Handlers
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public AddAuthorCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new AuthorEntity()
            {
                Name = request.Name,
                LastName = request.LastName
            };

            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
