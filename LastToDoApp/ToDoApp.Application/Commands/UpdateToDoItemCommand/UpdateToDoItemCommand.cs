using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Commands.UpdateToDoItemCommand

{
    public class UpdateToDoItemCommand : IRequest<ToDoItem>
    {
        public Guid Id { get; set; } 
        public string? Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}