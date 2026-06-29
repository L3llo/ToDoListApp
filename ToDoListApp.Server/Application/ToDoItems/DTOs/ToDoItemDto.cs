using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems.DTOs
{
    /// <summary>Read model returned by the API for a to-do item.</summary>
    public class ToDoItemDto
    {
        /// <summary>Unique identifier.</summary>
        public int Id { get; set; }
        /// <summary>Title of the task.</summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>Optional longer description.</summary>
        public string? Description { get; set; }
        /// <summary>Current state: <c>Open</c> or <c>Completed</c>.</summary>
        public ToDoItemState State { get; set; }
        /// <summary>UTC timestamp of when the item was created.</summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>UTC timestamp of when the item was completed. <see langword="null"/> if still open.</summary>
        public DateTime? CompletedAt { get; set; }
    }
}
