using Library.Domain.Db.Entities;
using Library.Domain.Db;
using Library.Infrastructure.Command;
using MediatR;

namespace Library.Infrastructure.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Unit>
    {
        private readonly AppDbContext _db;

        public AddBookCommandHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var author = await _db.Authors.FindAsync(request.AuthorId);

            if (author == null)
            {
                throw new ArgumentException("Author couldn't be found");
            }

            var book = new BookEntity
            {
                Author = author,
                Title = request.Title,
                Description = request.Description
            };

            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
