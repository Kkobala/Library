using MediatR;

namespace Library.Infrastructure.Command
{
    public class AddBookCommand : IRequest<Unit>
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public AddBookCommand(string title, string description, int authorId)
        {
            Title = title;
            Description = description;
            AuthorId = authorId;
        }
    }
}
