using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class APIDbContext : DbContext
{
    public APIDbContext(DbContextOptions<APIDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(APIDbContext).Assembly);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
}
