namespace ToDoListApp.Server.Application.ToDoItems.DTOs
{
    /// <summary>Payload for creating a new to-do item.</summary>
    public class CreateToDoItemDto
    {
        /// <summary>Title of the task. Required.</summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>Optional longer description.</summary>
        public string? Description { get; set; }
    }
}
