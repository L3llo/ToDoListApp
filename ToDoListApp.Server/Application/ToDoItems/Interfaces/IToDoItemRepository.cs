using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem?> GetByIdAsync(int id);
        Task<ToDoItem> AddAsync(ToDoItem item);
        Task<ToDoItem> UpdateAsync(ToDoItem item);
        Task DeleteAsync(int id);
    }
}
