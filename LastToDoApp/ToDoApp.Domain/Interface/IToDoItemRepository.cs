using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Interface
{
    public interface IToDoItemRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(string Id);
        Task<ToDoItem> AddAsync(ToDoItem toDoItem);
        Task<ToDoItem> UpdateAsync(ToDoItem toDoItem);
        Task<bool> DeleteAsync(string Id);
    }
}
