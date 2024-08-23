using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Queries.GetAllToDoItemsQuery
{
    public class GetAllToDoItemsQuery : IRequest<List<ToDoItem>> { }

}