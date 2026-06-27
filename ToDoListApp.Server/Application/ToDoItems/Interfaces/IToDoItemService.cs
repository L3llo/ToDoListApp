using ToDoListApp.Server.Application.ToDoItems.DTOs;

namespace ToDoListApp.Server.Application.ToDoItems.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItemDto>> GetAllAsync();
        Task<ToDoItemDto?> GetByIdAsync(int id);
        Task<ToDoItemDto> CreateAsync(CreateToDoItemDto dto);
        Task<ToDoItemDto> UpdateAsync(int id, UpdateToDoItemDto dto);
        Task DeleteAsync(int id);
    }
}
