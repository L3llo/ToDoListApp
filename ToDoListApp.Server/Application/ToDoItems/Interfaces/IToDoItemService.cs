using ToDoListApp.Server.Application.ToDoItems.DTOs;

namespace ToDoListApp.Server.Application.ToDoItems.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItemDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ToDoItemDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ToDoItemDto> CreateAsync(CreateToDoItemDto dto, CancellationToken cancellationToken = default);
        Task<ToDoItemDto> UpdateAsync(int id, UpdateToDoItemDto dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
