using ToDoListApp.Server.Application.Common.Exceptions;
using ToDoListApp.Server.Application.ToDoItems.DTOs;
using ToDoListApp.Server.Application.ToDoItems.Interfaces;
using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems
{
    public class ToDoItemService(IToDoItemRepository repository) : IToDoItemService
    {
        private readonly IToDoItemRepository _repository = repository;

        public async Task<ToDoItemDto> CreateAsync(CreateToDoItemDto dto, CancellationToken cancellationToken = default)
        {
            var item = new ToDoItem
            {
                Title = dto.Title,
                Description = dto.Description
            };

            var created = await _repository.AddAsync(item, cancellationToken);
            return MapToDto(created);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            _ = await _repository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"ToDoItem by id {id} not found.");
            await _repository.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<ToDoItemDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await _repository.GetAllAsync(cancellationToken);
            return items.Select(MapToDto);
        }

        public async Task<ToDoItemDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var item = await _repository.GetByIdAsync(id, cancellationToken);
            return item is null ? null : MapToDto(item);
        }

        public async Task<ToDoItemDto> UpdateAsync(int id, UpdateToDoItemDto dto, CancellationToken cancellationToken = default)
        {
            var item = await _repository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"ToDoItem by id {id} not found.");

            item.Title = dto.Title;
            item.Description = dto.Description;
            if (dto.State == ToDoItemState.Completed)
                item.MarkCompleted();
            else
                item.Reopen();

            var updated = await _repository.UpdateAsync(item, cancellationToken);
            return MapToDto(updated);
        }

        private static ToDoItemDto MapToDto(ToDoItem item) => new()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            State = item.State,
            CreatedAt = item.CreatedAt,
            CompletedAt = item.CompletedAt
        };
    }
}
