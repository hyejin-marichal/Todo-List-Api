using System.ComponentModel.Design;
using HyejinMarichal.Todolists.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HyejinMarichal.TodoLists.Database.Postgres
{
    public static class DatabaseExtension
    {
        public static void AddTodoListDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoItemContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("TodoList"),
                    opt => opt.MigrationsAssembly(typeof(DatabaseExtension).Assembly.FullName));
            });
        }
    }
}