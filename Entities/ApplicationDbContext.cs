using Microsoft.EntityFrameworkCore;

namespace FirstProject.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "T-shirt",
                    Price = 40,
                    Stock = 10
                },
                new Product
                {
                    Id = 2,
                    Name = "Jeans",
                    Price = 69.5m,
                    Stock = 25
                },
                new Product
                {
                    Id = 3,
                    Name = "Hoodie",
                    Price = 90,
                    Stock = 15
                }
            );
        }
    }
}