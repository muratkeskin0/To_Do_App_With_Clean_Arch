using MediatR;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interface;

namespace ToDoApp.Application.Queries.GetAllToDoItemsQuery
{
public class GetAllToDoItemsQueryHandler(IToDoItemRepository repository) : IRequestHandler<GetAllToDoItemsQuery, List<ToDoItem>>
    {
        private readonly IToDoItemRepository _repository = repository;

        public async Task<List<ToDoItem>> Handle(GetAllToDoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}