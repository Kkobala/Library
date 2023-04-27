using Library.App.Models.Requests;
using Library.Domain.Db;
using Library.Domain.Db.Entities;
using Library.Domain.Models.Requests;
using Library.Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Implementation
{
    public class BookCommandRepository : IBookCommandRepository
    {
        private readonly AppDbContext _db;

        public BookCommandRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(BookEntity book)
        {
            await _db.Books.AddAsync(book);
        }

        public void Update(BookEntity book)
        {
            _db.Books.Update(book);
        }

        public void Remove(BookEntity book)
        {
            _db.Books.Remove(book);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
