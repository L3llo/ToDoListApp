using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems.Interfaces
{
    /// <summary>Persistence gateway for <see cref="ToDoItem"/> entities.</summary>
    public interface IToDoItemRepository
    {
        /// <summary>Returns all to-do items.</summary>
        Task<IEnumerable<ToDoItem>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>Returns a single item by ID, or <see langword="null"/> if not found.</summary>
        Task<ToDoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>Persists a new item and returns it with its generated ID.</summary>
        Task<ToDoItem> AddAsync(ToDoItem item, CancellationToken cancellationToken = default);

        /// <summary>Persists changes to an existing item.</summary>
        Task<ToDoItem> UpdateAsync(ToDoItem item, CancellationToken cancellationToken = default);

        /// <summary>Deletes an item by ID. No-op if the ID does not exist.</summary>
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
