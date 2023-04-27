using Library.Domain.Db;
using Library.Domain.Db.Entities;
using Library.Domain.Models.Requests;
using Library.Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Implementation
{
    public class AuthorCommandRepository : IAuthorCommandRepository
    {
        private readonly AppDbContext _db;

        public AuthorCommandRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(AuthorEntity author)
        {
            await _db.Authors.AddAsync(author);
        }

        public void Remove(AuthorEntity author)
        {
            _db.Authors.Remove(author);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
