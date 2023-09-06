using Microsoft.EntityFrameworkCore;
using TPTodo.Models;

namespace TPTodo.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base() { }
        public DbSet<Todo> TodoList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\aspnet;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var defaultTask = new Todo()
            {
                Id = 1,
                Title = "Testing",
                Description = "Test if the program works",
                Done = false
            };

            modelBuilder.Entity<Todo>().HasData(defaultTask);
        }
    }
}
