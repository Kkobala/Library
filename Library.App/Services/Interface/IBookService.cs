using Library.App.Models.Requests;
using Library.App.Models;
using Library.Domain.Models.Requests;
using Library.Domain.Models;

namespace Library.App.Services.Interface
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(AddBookRequest request);
        Task<Book> UpdateBookAsync(UpdateBookRequest request);
        Task<PaginatedList<Book>> GetBooksByAuthorAsync(GetBookByAuthorRequest request);
        Task<PaginatedList<Book>> GetBooksAsync(GetBooksRequest request);
        Task RemoveBookAsync(RemoveBookRequest request);
    }
}
