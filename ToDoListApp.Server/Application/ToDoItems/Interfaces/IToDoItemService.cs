using ToDoListApp.Server.Application.ToDoItems.DTOs;

namespace ToDoListApp.Server.Application.ToDoItems.Interfaces
{
    /// <summary>Application service for to-do item CRUD operations.</summary>
    public interface IToDoItemService
    {
        /// <summary>Returns all to-do items.</summary>
        Task<IEnumerable<ToDoItemDto>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>Returns a single item by ID, or <see langword="null"/> if not found.</summary>
        Task<ToDoItemDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>Creates a new to-do item and returns the persisted result.</summary>
        Task<ToDoItemDto> CreateAsync(CreateToDoItemDto dto, CancellationToken cancellationToken = default);

        /// <summary>Updates an existing item. Throws <see cref="Common.Exceptions.NotFoundException"/> if the ID does not exist.</summary>
        Task<ToDoItemDto> UpdateAsync(int id, UpdateToDoItemDto dto, CancellationToken cancellationToken = default);

        /// <summary>Deletes an item by ID. Throws <see cref="Common.Exceptions.NotFoundException"/> if the ID does not exist.</summary>
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
