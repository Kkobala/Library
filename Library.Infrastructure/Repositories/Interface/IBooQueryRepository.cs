using Library.App.Models.Requests;
using Library.Domain.Db.Entities;
using Library.Domain.Models.Requests;

namespace Library.Infrastructure.Repositories.Interface
{
    public interface IBookQueryRepository
    {
        Task<BookEntity> FindBookAsync(UpdateBookRequest request);
        Task<BookEntity> FindBookWithTitleAsync(RemoveBookRequest request);
        Task<List<BookEntity>> GetBooksByAuthor(GetBookByAuthorRequest request);
        Task<List<BookEntity>> GetBooks(GetBooksRequest request);
        Task<int> CountBooksByAuthor(string authorName);
        Task<int> CountBooks();
    }
}
