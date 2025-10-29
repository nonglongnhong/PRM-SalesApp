using Microsoft.EntityFrameworkCore;
using OrderService.API.Models;

namespace OrderService.API.Data;

public class OrderDbContext(DbContextOptions<OrderDbContext> opt) : DbContext(opt)
{
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Order>(e =>
        {
            e.ToTable("Orders");
            e.HasKey(x => x.OrderID);
            e.Property(x => x.PaymentMethod).HasMaxLength(50).IsRequired();
            e.Property(x => x.BillingAddress).HasMaxLength(255).IsRequired();
            e.Property(x => x.OrderStatus).HasMaxLength(50).IsRequired();
            e.Property(x => x.OrderDate).HasDefaultValueSql("GETDATE()");
        });
    }
}
