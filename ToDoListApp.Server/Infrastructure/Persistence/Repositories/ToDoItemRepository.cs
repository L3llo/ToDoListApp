using Microsoft.EntityFrameworkCore;
using ToDoListApp.Server.Application.ToDoItems.Interfaces;
using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Infrastructure.Persistence.Repositories
{
    public class ToDoItemRepository(AppDbContext context) : IToDoItemRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ToDoItem> AddAsync(ToDoItem item, CancellationToken cancellationToken = default)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var item = await _context.ToDoItems.FindAsync([id], cancellationToken);
            if (item is not null)
            {
                _context.ToDoItems.Remove(item);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ToDoItems.ToListAsync(cancellationToken);
        }

        public async Task<ToDoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ToDoItems.FindAsync([id], cancellationToken);
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem item, CancellationToken cancellationToken = default)
        {
            _context.ToDoItems.Update(item);
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }
    }
}
