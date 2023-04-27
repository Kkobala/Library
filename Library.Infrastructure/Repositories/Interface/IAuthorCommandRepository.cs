using Library.Domain.Db.Entities;
using Library.Domain.Models.Requests;

namespace Library.Infrastructure.Repositories.Interface
{
    public interface IAuthorCommandRepository
    {
        Task AddAsync(AuthorEntity author);
        Task SaveChangesAsync();
        void Remove(AuthorEntity author);
    }
}
