using AspNetEx4.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetEx4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }

        public DbSet<Marmoset> Marmosets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\aspnet;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var marmosetDefault = new Marmoset()
            {
                Id = 1,
                Name = "Testing The First",
                Age = 100
            };

            modelBuilder.Entity<Marmoset>().HasData(marmosetDefault);
        }
    }
}
