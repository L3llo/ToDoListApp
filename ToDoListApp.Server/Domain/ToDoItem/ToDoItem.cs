namespace ToDoListApp.Server.Domain.ToDoItem
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ToDoItemState State { get; set; } = ToDoItemState.Open;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt {  get; set; }

    }
}
