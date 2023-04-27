using Library.App.Models.Requests;
using Library.Domain.Db.Entities;
using Library.Domain.Db;
using Library.Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Repositories.Interface;

namespace Library.Infrastructure.Repositories.Implementation
{
    public class BookQueryRepository : IBookQueryRepository
    {
        private readonly AppDbContext _db;

        public BookQueryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<BookEntity> FindBookAsync(UpdateBookRequest request)
        {
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == request.Id);

            if (book == null)
            {
                throw new ArgumentException("Book couldn't be found");
            }

            return book;
        }

        public async Task<BookEntity> FindBookWithTitleAsync(RemoveBookRequest request)
        {
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Title == request.Title);

            if (book == null)
            {
                throw new ArgumentException("Book couldn't be found");
            }

            return book;
        }

        public async Task<List<BookEntity>> GetBooksByAuthor(GetBookByAuthorRequest request)
        {
            var books = await _db.Books
                .Include(b => b.Author)
                .Where(b => b.Author.Name == request.AuthorName && b.Author.LastName == request.AuthorLastName)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return books;
        }

        public async Task<List<BookEntity>> GetBooks(GetBooksRequest request)
        {
            var books = await _db.Books
             .Include(b => b.Author)
             .Skip((request.PageIndex - 1) * request.PageSize)
             .Take(request.PageSize)
             .ToListAsync();

            return books;
        }
        public async Task<int> CountBooksByAuthor(string authorName)
        {
            var count = await _db.Books
                .Include(b => b.Author)
                .Where(b => b.Author.Name == authorName)
                .CountAsync();

            return count;
        }

        public async Task<int> CountBooks()
        {
            return await _db.Books.CountAsync();
        }
    }
}

