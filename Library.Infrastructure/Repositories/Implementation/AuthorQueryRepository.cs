using Library.Domain.Db;
using Library.Domain.Db.Entities;
using Library.Domain.Models.Requests;
using Library.Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Implementation
{
    public class AuthorQueryRepository : IAuthorQueryRepository
    {
        private readonly AppDbContext _db;

        public AuthorQueryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<AuthorEntity>> FindAuthorAsync(RemoveAuthorRequest request)
        {
            var author = await _db.Authors
                .Where(b => b.Name == request.Name
                && b.LastName == request.LastName)
                .ToListAsync();

            if (author == null)
            {
                throw new ArgumentException("Author couldn't be found");
            }

            return author;
        }

        public async Task<AuthorEntity> FindAuthorByIdAsync(int authorId)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(b => b.Id == authorId);

            if (author == null)
            {
                throw new ArgumentException($"Author with ID {authorId} not found.");
            }

            return author;
        }

        public async Task<AuthorEntity> FindAuthorByName(string authorName, string authorLastName)
        {
            var author = await _db.Authors
                .FirstOrDefaultAsync(a => a.Name == authorName
                && a.LastName == authorLastName);

            return author!;
        }

    }
}
