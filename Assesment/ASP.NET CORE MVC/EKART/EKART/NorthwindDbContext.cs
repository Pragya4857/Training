using EKART.Models;
using Microsoft.EntityFrameworkCore;

namespace EKART
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {
        }

        // Add DbSet properties for each entity
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        // Add DbSet properties for other entities as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships, constraints, etc.
        }
    }
}
