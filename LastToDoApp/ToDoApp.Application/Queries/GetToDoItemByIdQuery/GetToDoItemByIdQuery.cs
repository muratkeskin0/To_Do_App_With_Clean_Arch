using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Queries.GetToDoItemByIdQuery
{
    public class GetToDoItemByIdQuery : IRequest<ToDoItem?>
    {
        public Guid Id { get; set; }

        public GetToDoItemByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
