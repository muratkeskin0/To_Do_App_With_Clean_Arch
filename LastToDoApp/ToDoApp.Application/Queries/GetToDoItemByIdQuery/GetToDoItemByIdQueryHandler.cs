using MediatR;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interface;

namespace ToDoApp.Application.Queries.GetToDoItemByIdQuery
{
    public class GetToDoItemByIdQueryHandler : IRequestHandler<GetToDoItemByIdQuery, ToDoItem?>
    {
        private readonly IToDoItemRepository _repository;

        public GetToDoItemByIdQueryHandler(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItem?> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id.ToString());
        }
    }
}
