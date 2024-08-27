using HrApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Data
{
    public class HrApiContext : DbContext
    {
        public HrApiContext(DbContextOptions<HrApiContext> options) : base(options) { }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and other model configurations if necessary
            modelBuilder.Entity<Country>().HasKey(c => c.CountryId);
            modelBuilder.Entity<Employee>().HasOne(e => e.Manager).WithMany().HasForeignKey(e => e.ManagerId);
        }
    }
}
