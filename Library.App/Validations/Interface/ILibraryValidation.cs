namespace Library.App.Validations.Interface
{
    public interface ILibraryValidation
    {
        void CheckAuthorName(string firstName, string lastName);
        void CheckBookTitle(string title);
        Task CheckAuthorIdAsync(int authorId);
    }
}
