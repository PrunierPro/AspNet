using Microsoft.EntityFrameworkCore;
using TPCaisse.Models;

namespace TPCaisse.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(): base() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\aspnet;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Category defaultCategory = new Category()
            {
                Id = 1,
                Name = "Default",
            };
            modelBuilder.Entity<Category>().HasData(defaultCategory);
        }
    }
}
