using Library.App.Models;
using Library.App.Models.Requests;
using Library.App.Services.Interface;
using Library.App.Validations.Interface;
using Library.Domain.Db.Entities;
using Library.Domain.Models;
using Library.Domain.Models.Requests;
using Library.Infrastructure.UnitOfWork;

namespace Library.App.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryValidation _bookValidation;

        public BookService(
            IUnitOfWork unitOfWork,
            ILibraryValidation bookValidation)
        {
            _unitOfWork = unitOfWork;
            _bookValidation = bookValidation;
        }

        public async Task<Book> AddBookAsync(AddBookRequest request)
        {
            var book = new BookEntity()
            {
                AuthorId = request.AuthorId,
                Title = request.Title,
                Description = request.Description,
            };

            _bookValidation.CheckBookTitle(request.Title);

            await _unitOfWork.BookCommandRepository.AddAsync(book);
            await _unitOfWork.BookCommandRepository.SaveChangesAsync();

            var addedBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
            };

            return addedBook;
        }

        public async Task<Book> UpdateBookAsync(UpdateBookRequest request)
        {
            var updatedBook = await _unitOfWork.BookQueryRepository.FindBookAsync(request);

            updatedBook.Title = request.Title;
            updatedBook.Description = request.Description;

            _bookValidation.CheckBookTitle(request.Title);

            _unitOfWork.BookCommandRepository.Update(updatedBook);
            await _unitOfWork.BookCommandRepository.SaveChangesAsync();

            var book = new Book()
            {
                Title = updatedBook.Title,
                Description = updatedBook.Description,
            };

            return book;
        }

        public async Task<PaginatedList<Book>> GetBooksByAuthorAsync(GetBookByAuthorRequest request)
        {
            var bookEntities = await _unitOfWork.BookQueryRepository.GetBooksByAuthor(request);

            var books = bookEntities.Select(b => new Book()
            {
                Title = b.Title,
                Description = b.Description,
                Author = new AuthorEntity()
                {
                    Name = b.Author.Name,
                    LastName = b.Author.LastName
                }
            }).ToList();

            var totalCount = await _unitOfWork.BookQueryRepository.CountBooksByAuthor(request.AuthorName);
            var paginatedList = new PaginatedList<Book>(books, totalCount, request.PageIndex, request.PageSize);

            return paginatedList;
        }

        public async Task<PaginatedList<Book>> GetBooksAsync(GetBooksRequest request)
        {
            var bookEntities = await _unitOfWork.BookQueryRepository.GetBooks(request);

            var book = bookEntities.Select(b => new Book()
            {
                Title = b.Title,
                Description = b.Description,
                Author = new AuthorEntity()
                {
                    Name = b.Author.Name,
                    LastName = b.Author.LastName
                }
            }).ToList();

            var totalCount = await _unitOfWork.BookQueryRepository.CountBooks();
            var paginatedList = new PaginatedList<Book>(book, totalCount, request.PageIndex, request.PageSize);

            return paginatedList;
        }

        public async Task RemoveBookAsync(RemoveBookRequest request)
        {
            var removeBook = await _unitOfWork.BookQueryRepository.FindBookWithTitleAsync(request);

            _unitOfWork.BookCommandRepository.Remove(removeBook);
            await _unitOfWork.BookCommandRepository.SaveChangesAsync();
        }
    }
}
