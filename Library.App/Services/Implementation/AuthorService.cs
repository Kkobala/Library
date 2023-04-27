using Library.App.Models;
using Library.App.Services.Interface;
using Library.App.Validations.Interface;
using Library.Domain.Db.Entities;
using Library.Domain.Models.Requests;
using Library.Infrastructure.Repositories.Interface;
using Library.Infrastructure.UnitOfWork;

namespace Library.App.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryValidation _libraryValidation;

        public AuthorService(IUnitOfWork unitOfWork,
            ILibraryValidation libraryValidation)
        {
            _unitOfWork = unitOfWork;
            _libraryValidation = libraryValidation;
        }

        public async Task<Author> AddAuthorAsync(AddAuthorRequest request)
        {
            var author = new AuthorEntity()
            {
                Name = request.Name,
                LastName = request.LastName,
            };

            _libraryValidation.CheckAuthorName(request.Name, request.LastName);

            await _unitOfWork.AuthorCommandRepository.AddAsync(author);
            await _unitOfWork.AuthorCommandRepository.SaveChangesAsync();

            var addedAuthor = new Author()
            {
                AuthorId = author.Id,
                Name = author.Name,
                LastName = author.LastName,
            };

            return addedAuthor;
        }

        public async Task DeleteAuthorAsync(RemoveAuthorRequest request)
        {
            var authors = await _unitOfWork.AuthorQueryRepository.FindAuthorAsync(request);

            if (authors == null || authors.Count == 0)
            {
                throw new ArgumentException("Author not found");
            }

            foreach (var author in authors)
            {
                var books = await _unitOfWork.BookQueryRepository.GetBooksByAuthor(new GetBookByAuthorRequest
                { AuthorName = author.Name, PageIndex = 1, PageSize = int.MaxValue });

                foreach (var book in books)
                {
                    _unitOfWork.BookCommandRepository.Remove(book);
                }

                _unitOfWork.AuthorCommandRepository.Remove(author);
            }

            await _unitOfWork.AuthorCommandRepository.SaveChangesAsync();
        }
    }
}
