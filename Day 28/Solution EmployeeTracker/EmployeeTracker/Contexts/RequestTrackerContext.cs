using EmployeeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracker.Contexts
{
    public class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<Employee>().HasKey(e => e.Id);

            modelBuilder.Entity<Request>().HasKey(r => r.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.RaisedByEmployee)
                .WithMany(e => e.RequestRaised)
                .HasForeignKey(r => r.RaisedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.ClosedByEmployee)
                .WithMany(e => e.RequestClosed)
                .HasForeignKey(r => r.ClosedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
