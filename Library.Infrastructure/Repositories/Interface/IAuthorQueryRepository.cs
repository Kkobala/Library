using Library.Domain.Db.Entities;
using Library.Domain.Models.Requests;

namespace Library.Infrastructure.Repositories.Interface
{
    public interface IAuthorQueryRepository
    {
        Task<List<AuthorEntity>> FindAuthorAsync(RemoveAuthorRequest request);
        Task<AuthorEntity> FindAuthorByName(string authorName, string authorLastName);
        Task<AuthorEntity> FindAuthorByIdAsync(int authorId);
    }
}
