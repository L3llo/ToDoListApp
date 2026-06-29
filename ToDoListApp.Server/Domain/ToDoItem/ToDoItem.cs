namespace ToDoListApp.Server.Domain.ToDoItem
{
    public class ToDoItem
    {
        public int Id { get; private set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ToDoItemState State { get; private set; } = ToDoItemState.Open;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; private set; }

        public void MarkCompleted()
        {
            if (State == ToDoItemState.Completed) return;
            State = ToDoItemState.Completed;
            CompletedAt = DateTime.UtcNow;
        }

        public void Reopen()
        {
            if (State == ToDoItemState.Open) return;
            State = ToDoItemState.Open;
            CompletedAt = null;
        }
    }
}
