using Library.Infrastructure.Repositories.Interface;
using Library.Infrastructure.UnitOfWork;

namespace Library.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IAuthorCommandRepository authorCommandRepository,
            IBookCommandRepository bookCommandRepository,
            IAuthorQueryRepository authorQueryRepository,
            IBookQueryRepository booQueryRepository)
        {
            AuthorCommandRepository = authorCommandRepository;
            BookCommandRepository = bookCommandRepository;
            BookQueryRepository = booQueryRepository;
            AuthorQueryRepository = authorQueryRepository;
        }

        public IAuthorCommandRepository AuthorCommandRepository { get; set; }
        public IBookCommandRepository BookCommandRepository { get; set; }
        public IAuthorQueryRepository AuthorQueryRepository { get; set; }
        public IBookQueryRepository BookQueryRepository { get; set; }
    }
}
