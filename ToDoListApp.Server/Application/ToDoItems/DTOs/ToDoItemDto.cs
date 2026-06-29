using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems.DTOs
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ToDoItemState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
