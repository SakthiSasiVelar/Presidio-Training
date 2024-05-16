using Microsoft.EntityFrameworkCore;
using PizzaStoreManagement.Models;

namespace PizzaStoreManagement.Contexts
{
    public class PizzaStoreManagementDbContext:DbContext
    {
        public PizzaStoreManagementDbContext(DbContextOptions options): base(options) { }
       
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
