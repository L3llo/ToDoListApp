using Microsoft.EntityFrameworkCore;
using ToDoListApp.Server.Application.ToDoItems.Interfaces;
using ToDoListApp.Server.Domain.ToDoItem;

namespace ToDoListApp.Server.Infrastructure.Persistence.Repositories
{
    public class ToDoItemRepository(AppDbContext context) : IToDoItemRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ToDoItem> AddAsync(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item is not null)
            {
                _context.ToDoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem?> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem item)
        {
            _context.ToDoItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
