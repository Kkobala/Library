using MediatR;

namespace Library.Infrastructure.Command
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public UpdateBookCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
