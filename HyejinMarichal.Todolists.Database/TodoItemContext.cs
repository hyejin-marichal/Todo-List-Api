using Microsoft.EntityFrameworkCore;

namespace HyejinMarichal.Todolists.Database
{
    public class TodoItemContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoItemContext(DbContextOptions<TodoItemContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TodoItemEntityTypeConfiguration());
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoItemContext).Assembly); # dans un gros projet pour automatiquement
        }
    }
}