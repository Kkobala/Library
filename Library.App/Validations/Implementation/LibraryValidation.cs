using Library.App.Validations.Interface;
using Library.Infrastructure.UnitOfWork;

namespace Library.App.Validations.Implementation
{
    public class LibraryValidation : ILibraryValidation
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CheckAuthorName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("Author first name cannot be empty.");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Author last name cannot be empty.");
            }
        }

        public void CheckBookTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Book title cannot be empty.");
            }
        }

        public async Task CheckAuthorIdAsync(int authorId)
        {
            var author = await _unitOfWork.AuthorQueryRepository.FindAuthorByIdAsync(authorId);

            if (author == null)
            {
                throw new ArgumentException("Invalid author ID specified.");
            }
        }
    }
}
