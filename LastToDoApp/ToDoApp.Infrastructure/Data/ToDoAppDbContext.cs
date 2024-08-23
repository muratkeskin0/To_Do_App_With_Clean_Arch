using ToDoApp.Domain.Entities;

namespace ToDoApp.Infrastructure.Data
{
    public class ToDoAppDbContext
    {
        // This list will act as the in-memory database for ToDoItems
        public List<ToDoItem> ToDoItems { get; set; }

        public ToDoAppDbContext()
        {
            // Initialize the list to avoid null reference issues
            ToDoItems = new List<ToDoItem>();
        }
    }
}
