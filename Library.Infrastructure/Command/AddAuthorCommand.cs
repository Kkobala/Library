using MediatR;

namespace Library.Infrastructure.Command
{
    public class AddAuthorCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public AddAuthorCommand(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }
    }
}
