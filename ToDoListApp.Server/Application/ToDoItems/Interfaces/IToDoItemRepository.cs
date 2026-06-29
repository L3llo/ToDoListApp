using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ToDoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ToDoItem> AddAsync(ToDoItem item, CancellationToken cancellationToken = default);
        Task<ToDoItem> UpdateAsync(ToDoItem item, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
