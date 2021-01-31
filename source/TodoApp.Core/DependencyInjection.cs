using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TodoApp.Core.EntityFramework;
using TodoApp.Core.Repositories;

namespace TodoApp.Core
{
    public static class DependencyInjection
    {
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sql");
            services.AddDbContext<TodoAppDbContext>(
            options =>
            options.UseSqlServer(connectionString));

            services.AddTransient<ITodoRepository, TodoRepository>();
        }
    }
}
