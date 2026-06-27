using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems.DTOs
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string State { get; set; } = string.Empty; // Converted in string because of JSON serialization.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }
}
