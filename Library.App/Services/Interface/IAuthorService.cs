using Library.App.Models;
using Library.Domain.Models.Requests;

namespace Library.App.Services.Interface
{
    public interface IAuthorService
    {
        Task<Author> AddAuthorAsync(AddAuthorRequest request);
        Task DeleteAuthorAsync(RemoveAuthorRequest request);
    }
}
