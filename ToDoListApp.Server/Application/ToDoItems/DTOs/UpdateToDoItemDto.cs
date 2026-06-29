using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Application.ToDoItems.DTOs
{
    /// <summary>Payload for updating an existing to-do item.</summary>
    public class UpdateToDoItemDto
    {
        /// <summary>Updated title. Required.</summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>Updated description.</summary>
        public string? Description { get; set; }
        /// <summary>New state.</summary>
        public ToDoItemState State { get; set; }
    }
}
