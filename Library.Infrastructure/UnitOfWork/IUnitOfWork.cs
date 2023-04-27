using Library.Infrastructure.Repositories.Interface;

namespace Library.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAuthorCommandRepository AuthorCommandRepository { get; set; }
        public IBookCommandRepository BookCommandRepository { get; set; }
        public IAuthorQueryRepository AuthorQueryRepository { get; set; }
        public IBookQueryRepository BookQueryRepository { get; set; }
    }
}
