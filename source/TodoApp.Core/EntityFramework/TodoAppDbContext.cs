using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Core.EntityFramework
{
    public class TodoAppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options)
            : base(options)
        {
        }
    }
}
