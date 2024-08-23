using MediatR;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interface;


namespace ToDoApp.Application.Commands.CreateToDoItemCommand
{
    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, ToDoItem>
    {
        private readonly IToDoItemRepository _repository;

        public CreateToDoItemCommandHandler(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItem> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = new ToDoItem
            {
                Id = Guid.NewGuid(),
                Task = request.Task,
                IsCompleted = request.IsCompleted
            };

            cancellationToken.ThrowIfCancellationRequested();

            return await _repository.AddAsync(toDoItem);
        }
    }
}
