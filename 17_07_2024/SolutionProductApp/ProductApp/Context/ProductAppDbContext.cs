using Microsoft.EntityFrameworkCore;
using ProductApp.Models;
using static System.Net.WebRequestMethods;

namespace ProductApp.Context
{
    public class ProductAppDbContext : DbContext 
    {
        public ProductAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(x => x.Id);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pencil",
                    Price = "5",
                    ImageUrl = "https://storagesakthisasivelar.blob.core.windows.net/productapp/pencil.png"
                },
                new Product
                {
                    Id = 2,
                    Name = "Eraser",
                    Price = "3",
                    ImageUrl = "https://storagesakthisasivelar.blob.core.windows.net/productapp/ERASER.jfif"
                }
                );
        }
    }
}
