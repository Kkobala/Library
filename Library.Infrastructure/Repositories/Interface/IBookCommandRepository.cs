using Library.App.Models.Requests;
using Library.Domain.Db.Entities;
using Library.Domain.Models.Requests;

namespace Library.Infrastructure.Repositories.Interface
{
    public interface IBookCommandRepository
    {
        Task AddAsync(BookEntity book);
        Task SaveChangesAsync();
        void Update(BookEntity book);
        void Remove(BookEntity book);
    }
}
