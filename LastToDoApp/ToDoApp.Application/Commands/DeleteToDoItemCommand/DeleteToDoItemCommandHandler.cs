using MediatR;
using ToDoApp.Domain.Interface;

namespace ToDoApp.Application.Commands.DeleteToDoItemCommand
{
    public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand, bool>
    {
        private readonly IToDoItemRepository _repository;

        public DeleteToDoItemCommandHandler(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.DeleteAsync(request.Id.ToString());

            cancellationToken.ThrowIfCancellationRequested();
            
            return success;
        }
    }
}
