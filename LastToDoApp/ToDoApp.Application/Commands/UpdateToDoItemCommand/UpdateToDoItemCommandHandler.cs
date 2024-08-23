using MediatR;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interface;

namespace ToDoApp.Application.Commands.UpdateToDoItemCommand
{
    public class UpdateToDoItemCommandHandler(IToDoItemRepository repository) : IRequestHandler<UpdateToDoItemCommand, ToDoItem>
    {
        private readonly IToDoItemRepository _repository = repository;

        public async Task<ToDoItem> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing ToDoItem from the repository
            var existingItem = await _repository.GetByIdAsync(request.Id.ToString());

            if (existingItem == null)
            {
                throw new KeyNotFoundException($"ToDoItem with Id {request.Id} was not found.");
            }

            // Update the properties with the new values from the command
            /*if (request.Task != null)
            {
                existingItem.Task = request.Task;
            }
            else
            {
                existingItem.Task = existingItem.Task;
            }*/
            existingItem.Task = request.Task ?? existingItem.Task; // If task is null, keep the old value
            existingItem.IsCompleted = request.IsCompleted;

            cancellationToken.ThrowIfCancellationRequested();

            // Save the changes to the repository
            return await _repository.UpdateAsync(existingItem);
        }
    }
}