using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interface;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoAppDbContext _toDoAppDbContext;

        public ToDoItemRepository(ToDoAppDbContext toDoAppDbContext)
        {
            _toDoAppDbContext = toDoAppDbContext;
        }

        public async Task<ToDoItem> AddAsync(ToDoItem toDoItem)
        {
            // Add the new ToDoItem to the list
            _toDoAppDbContext.ToDoItems.Add(toDoItem);
            return await Task.FromResult(toDoItem);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            // Find the item by id
            var item = _toDoAppDbContext.ToDoItems.FirstOrDefault(x => x.Id.ToString() == id);
            if (item != null)
            {
                // Remove the item if found
                _toDoAppDbContext.ToDoItems.Remove(item);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            // Return all ToDoItems in the list
            return await Task.FromResult(_toDoAppDbContext.ToDoItems);
        }

        public async Task<ToDoItem> GetByIdAsync(string id)
        {
            // Find the item by id and return it
            var item = _toDoAppDbContext.ToDoItems.FirstOrDefault(x => x.Id.ToString() == id);
            if(item != null){
                 return  await Task.FromResult(item);
            }
            throw new KeyNotFoundException($"ToDoItem with id {id} was not found.");
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem toDoItem)
        {
            // Find the existing item by id
            var existingItem = _toDoAppDbContext.ToDoItems.FirstOrDefault(x => x.Id == toDoItem.Id);
            if (existingItem != null)
            {
                // Update the task and isCompleted status
                existingItem.Task = toDoItem.Task;
                existingItem.IsCompleted = toDoItem.IsCompleted;
                return await Task.FromResult(existingItem);
            }
            throw new KeyNotFoundException($"ToDoItem was not found.");
            
        }
    }
}
