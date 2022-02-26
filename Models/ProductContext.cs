using Microsoft.EntityFrameworkCore;

namespace rest_api.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 1,
                Type = "keyboard",
                Manufacturer = "company1",
                Price = 50.35,
                Stock = 10
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 2,
                Type = "keyboard",
                Manufacturer = "company2",
                Price = 39.00,
                Stock = 0
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 3,
                Type = "mouse",
                Manufacturer = "company1",
                Price = 15.95,
                Stock = 2
            });
        }
    }
}
