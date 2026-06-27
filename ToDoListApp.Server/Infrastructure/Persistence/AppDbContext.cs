using Microsoft.EntityFrameworkCore;
using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.Property(e => e.State)
                    .HasConversion<string>()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedAt)
                    .IsRequired();
            });
        }
    }
}
