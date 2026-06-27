using ToDoListApp.Server.Application.ToDoItems.DTOs;
using ToDoListApp.Server.Application.ToDoItems.Interfaces;
using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems
{
    public class ToDoItemService(IToDoItemRepository repository) : IToDoItemService
    {
        private readonly IToDoItemRepository _repository = repository;

        public async Task<ToDoItemDto> CreateAsync(CreateToDoItemDto dto)
        {
            var item = new ToDoItem
            {
                Title = dto.Title,
                Description = dto.Description
            };

            var created = await _repository.AddAsync(item);
            return MapToDto(created);
        }

        public async Task DeleteAsync(int id)
        {
            _ = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"ToDoItem by id {id} not found.");
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ToDoItemDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(MapToDto);
        }

        public async Task<ToDoItemDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item is null ? null : MapToDto(item);
        }

        public async Task<ToDoItemDto> UpdateAsync(int id, UpdateToDoItemDto dto)
        {
            var item = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"ToDoItem by id {id} not found.");

            item.Title = dto.Title;
            item.Description = dto.Description;
            if (Enum.TryParse<ToDoItemState>(dto.State, out var state))
            {
                item.State = state;
                if (state == ToDoItemState.Completed && item.CompletedAt is null)
                    item.CompletedAt = DateTime.UtcNow;
                else if (state == ToDoItemState.Open)
                    item.CompletedAt = null;
            }

            var updated = await _repository.UpdateAsync(item);
            return MapToDto(updated);
        }

        private static ToDoItemDto MapToDto(ToDoItem item) => new()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            State = item.State.ToString(),
            CreatedAt = item.CreatedAt,
            CompletedAt = item.CompletedAt
        };
    }
}
