using Microsoft.EntityFrameworkCore;

namespace ClinicManagementApp.Models
{
    public class ClinicManagementDbContext : DbContext
    {
        public ClinicManagementDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(x => x.Id);
        }

    }
}
