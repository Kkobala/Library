using MediatR;

namespace Library.Infrastructure.Command
{
    public class RemoveBookCommand : IRequest<Unit>
    {
        public string Title { get; set; }

        public RemoveBookCommand(string title)
        {
            Title = title;
        }
    }
}
