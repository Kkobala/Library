using MediatR;

namespace Library.Infrastructure.Command
{
    public class RemoveAuthorCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public RemoveAuthorCommand(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }
    }
}
