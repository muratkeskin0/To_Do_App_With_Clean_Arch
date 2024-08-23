using MediatR;

namespace ToDoApp.Application.Commands.DeleteToDoItemCommand
{
    public class DeleteToDoItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteToDoItemCommand(Guid id)
        {
            Id = id;
        }
    }
}
