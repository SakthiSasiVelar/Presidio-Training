using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=BusBooking;User Id=sa;Password=Password!123;TrustServerCertificate=True;MultipleActiveResultSets=true");
    }
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
}
