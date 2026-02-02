using Microsoft.EntityFrameworkCore;
using DeliveryService.Models;

namespace DeliveryService.DataAccess;

public class DeliveryDbContext : DbContext
{
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderNumber)
                .IsRequired();
        });
    }
}
