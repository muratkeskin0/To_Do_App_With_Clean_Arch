using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Commands.CreateToDoItemCommand
{
    public class CreateToDoItemCommand : IRequest<ToDoItem>
    {
        public string? Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
