using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.EntityFramework;

namespace TodoApp.Core.Repositories
{
    public interface ITodoRepository
    {
        Task AddAsync(string description);
        Task MarkDoneAsync(int id);
        Task<IEnumerable<TodoItem>> GetAllAsync();
    }

    public class TodoRepository : ITodoRepository
    {
        private TodoAppDbContext dbContext;

        public TodoRepository(TodoAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(string description)
        {
            var item = new TodoItem()
            {
                Description = description,
                CreatedDate = DateTime.UtcNow
            };

            dbContext.Add(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await dbContext.TodoItems.Where(x => !x.IsDone).ToListAsync();
        }

        public async Task MarkDoneAsync(int id)
        {
           var item = await dbContext.TodoItems.FindAsync(id);
           item.IsDone = true;
           await dbContext.SaveChangesAsync();
        }
    }
}
